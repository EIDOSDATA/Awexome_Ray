////////////////////////////////////////////////////////////////////////////////
// timer0 : 8 bit
// timer1 : 16 bit (1<->3)
// timer2 : 8 bit  (OC21 -> PWM)
// timer3 : 16 bit 
////////////////////////////////////////////////////////////////////////////////

#include <avr/io.h>
#include <util/atomic.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include <avr/eeprom.h>
	
#include <avr/power.h>
#include <stdio.h>
#include <string.h>
#include <stdint.h>


#include "hw.h"
#include "uart.h"
#include "CLCD.h"

// ----------------------------------------------------------------------------
// EEPROM

EEPROM_CONFIG eeprom_pad;
EEPROM_CONFIG *EEPROM_PTR = (EEPROM_CONFIG *)NULL;

ADC_CHAN adc_buf[7];		//ch0, ch1

// ----------------------------------------------------------------------------
// 10bit resolution

void ADC_init()
{
  for(uint8_t i=0; i<2; i++) memset((void *)&adc_buf[i], 0, sizeof(ADC_CHAN));
   
  // ADC init  :  10 bit, ADC7(EP_TP)   ADC0(IP_TP)
  ADCSRA |= ((1<<ADPS2)|(1<<ADPS1)|(1<<ADPS0)); //16Mhz/128 = 125Khz
  ADMUX |= (1<<REFS0);      //AVCC(5V)
  ADCSRA |= (1<<ADEN);      //ADC 인에이블 		
}

uint16_t ADC_read(int channel)
{
  uint16_t sum=0;
  ADC_CHAN *p = &adc_buf[channel];
  
  ADMUX &= 0xF0;  
  ADMUX |= channel;  
  ADCSRA |= (1<<ADSC);      //변환 시작  
  while(ADCSRA&(1<<ADSC));  //변환 완료되기를 기다림.
  
  p->val[p->pos] = ADCW;
  p->pos++;
  if(p->pos >= MAX_ADC_LEN) p->pos = 0;
  
  for(uint8_t i=0; i<MAX_ADC_LEN; i++) sum += p->val[i];
  
  return(sum>>4);                    //Returns average ADC value 
}

// ----------------------------------------------------------------------------
uint8_t Key_read()
{
  static uint8_t old;
  uint8_t tmp, press;
  
  tmp = (~PINC & 0x0E) ;   //[7..0] =[UP,0,0,DN,0,0,PWR,NXT]
  press = old ^ tmp;
  old = tmp;
  if(press > 0) {
	if((press & 0x02) > 0) {
	  if((tmp & 0x02) > 0)  return KEY_UP_ON;
	  else return KEY_NONE;
	}else if((press & 0x04) > 0) {
	  if((tmp & 0x04) > 0)  return KEY_DN_ON;
	  else return KEY_NONE;
	}else if((press & 0x08) > 0) {
	  if((tmp & 0x08) > 0)  return KEY_PWR_ON;
	  else return KEY_NONE;		
	}  } else {
	return KEY_NONE;
  }
  return KEY_NONE;
}


// ----------------------------------------------------------------------------
void EEPROM_init()
{
  uint32_t tmp;
  
  memset((char *)&eeprom_pad, 0, sizeof(EEPROM_CONFIG));
  
  __EEGET(tmp, 0);
   
  if(tmp != EEPROM_MAGIC_NUM) {
    for(int i=0; i<3; i++) {
	  EEPROM_write(EEPROM_INV_KV_VAL, i, 30);		 //DEFAULT_KV_VAL
      EEPROM_write(EEPROM_INV_OFFSET, i, 0);  	
	  //LCD_display(4, "no magic number");
	}
	EEPROM_write(EEPROM_ELAPLSED_TIME, 0, 0);  
    EEPROM_write(EEPROM_FLAG, 0, EEPROM_MAGIC_NUM);  
	  //LCD_display(4, "eeprom magic ???");
	//printf("Info : EEPROM init.\r\n");
  } else {
	eeprom_pad.magic_num = eeprom_read_byte((uint8_t *)(&EEPROM_PTR->magic_num));
	for(tmp=0; tmp<3; tmp++) {
      eeprom_pad.kv[tmp] = eeprom_read_word((uint16_t *)(&EEPROM_PTR->kv[tmp]));  
	  eeprom_pad.offset[tmp] = eeprom_read_word((uint16_t *)(&EEPROM_PTR->offset[tmp]));
	}
	eeprom_pad.elapsed_min = eeprom_read_dword((uint32_t *)(&EEPROM_PTR->elapsed_min));
	//printf("Info : EEPROM load.\r\n");
	//LCD_display(4, "loading eeprom");
}

//_delay_ms(3000*10);

}

int32_t EEPROM_read(uint8_t item, uint8_t param)
{
  int32_t val = 0;
  
  switch(item)
  {
	case EEPROM_FLAG :
	  val = eeprom_pad.magic_num;
	  break;
    case EEPROM_INV_KV_VAL :
	  val = eeprom_pad.kv[param];
	  break;
    case EEPROM_INV_OFFSET :
	  val = eeprom_pad.offset[param];
	  break;
	case EEPROM_ELAPLSED_TIME :
	  val = eeprom_pad.elapsed_min;
	  break;  
	default : break;
  }
  
  return(val);   
}

void EEPROM_write(uint8_t item, uint8_t param, int32_t val)
{
  switch(item)
  {
	case   EEPROM_FLAG :
	  eeprom_pad.magic_num = val;
	  eeprom_write_byte((uint8_t *)(&EEPROM_PTR->magic_num), val); 
	  break;
    case EEPROM_INV_KV_VAL :
	  eeprom_pad.kv[param] = val;
	  eeprom_write_word((uint16_t *)(&EEPROM_PTR->kv[param]), val);   
	  break;
    case EEPROM_INV_OFFSET :
	  eeprom_pad.offset[param] = val;
	  eeprom_write_word((uint16_t *)(&EEPROM_PTR->offset[param]), val);   	  
	  break;
    case EEPROM_ELAPLSED_TIME :
	  eeprom_pad.elapsed_min = val;
	  eeprom_write_dword((uint32_t *)(&EEPROM_PTR->elapsed_min), val);   		  
	  break;	  
	default : break;
  }
  
}

// ----------------------------------------------------------------------------
void WatchDog()
{
  
}
// ----------------------------------------------------------------------------
// kv : 0~99 (-0.0kv ~ -9.9kv)
// PWM(8 bit) : 0~255 => 0~5V => 0 ~ -10KV (1V =>2KV)
// careful : OCR=0 ->expect out=0 but glitch accurs
void pwm_init()
{	  
	  DDRB |= (1<<PIN1);	//OC1A
	  TCCR1A |= (1<<COM1A1)|(1<<WGM11)|(1<<WGM10);		
	  TCCR1B |= (1<<CS11) ;								
	  OCR1A = 0;
	  TCNT1 = 0;  
}

void pwm_duty(uint8_t duty)
{   

  OCR1A = (uint16_t) duty*4;

}

// ----------------------------------------------------------------------------
// millis() : use timer0

volatile uint64_t  milliseconds;

#define CLOCKSEL (_BV(CS20))
#define PRESCALER 1

#define REG_TCCRA		TCCR2A
#define REG_TCCRB		TCCR2B
#define REG_TIMSK		TIMSK2
#define REG_OCR			OCR2A
#define BIT_WGM			WGM22
#define BIT_OCIE		OCIE2A

#define TIMER_ISR_VECT		TIMER2_COMPA_vect

#define SET_TCCRA()	(REG_TCCRA = 0)
#define SET_TCCRB()	(REG_TCCRB = _BV(BIT_WGM)|CLOCKSEL |2 )
// Initialize library
void millis_init()
{
	// Timer settings
	SET_TCCRA();
	SET_TCCRB();
	REG_TIMSK = _BV(BIT_OCIE);
	REG_OCR = ((F_CPU / PRESCALER) / 1000);

    milliseconds = 0;
}

// Get current milliseconds
uint64_t millis()
{
	uint64_t ms;
	ATOMIC_BLOCK(ATOMIC_FORCEON)
	{
		ms = milliseconds;
	}
	return ms;
}

ISR(TIMER_ISR_VECT)
{
	milliseconds++;

}

uint64_t setTimer(uint64_t t)
{
  uint64_t ms;
  
  ms = millis() + t;
  return ms;
}

uint8_t checkTimer(uint64_t timer_id)
{
  int64_t delta;
 
  delta = millis() - timer_id;
  if(delta >= 0) return 1;
  else return 0;
}

// ----------------------------------------------------------------------------
void blinkSysLED()
{
	static uint64_t timer=0;
	
	if(checkTimer(timer)) {
		SYS_LED_TOGGLE;			//toggle
		timer = setTimer(500);
	}
}

void mcu_soft_reset(void)
{
	asm volatile("jmp 0x0000");	
}

// ----------------------------------------------------------------------------
void hw_init()
{  
  cli();
  


  DDRB=0xFE;    //1111-1111 PWM(PB4) RUN(PB5)=0, RST(PB6)=0
  PORTB=0x00;   //DISABLE ALL OUTPUT
  
  DDRC=0x00;    //0000-0000   8PIN DIPSW
  //PORTC=0xFF;   //enable input pull-up  
  
  DDRD=0x30 ;   //000000000  UP(PD4), DN(PD7) : TO USE i2C DDR0, DDR1 should be 0  
  PORTD=0xF0;   //PD6,7 Pull-UP  
  EICRA =0x0A; //EXT INT0 AND EXT INT1 FALLING INT
  EIMSK = 0x03 ; //ext int0 and ext in1 interrupt enalbe
 

  // ADC init  :  10 bit, ADC0(EP_TP)   ADC1(IP_TP)
  ADCSRA |= ((1<<ADPS2)|(1<<ADPS1)|(1<<ADPS0)); //16Mhz/128 = 125Khz
  ADMUX |= (1<<REFS0);      //AVCC(5V)
  ADCSRA |= (1<<ADEN);      //ADC 인에이블
  
  // UART init : 57600 @ 16Mhz, 8bit, no flow control, 1 stopbit  
//  uart_init(0, 57600);

  // Tick init
  millis_init();

  //PWM init  : 4KHz, 0~80% duty change  
  pwm_init();
 
  LCD_Init(LCD_ADDR);  
	
  LCD_onoff(OFF);
  _delay_ms(1000);    
  
  //sei();
  
}
