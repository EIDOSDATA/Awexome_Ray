#ifndef _HW_H_
#define _HW_H_

#include <stdint.h>
#include <avr/interrupt.h>

#define PIN0 0
#define PIN1 1
#define PIN2 2
#define PIN3 3
#define PIN4 4
#define PIN5 5
#define PIN6 6
#define PIN7 7

// ----------------------------------------------------------------------------
#define RS232_PORT0   0
#define RS232_PORT1   1
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
//ADC
#define ADC_CH_IP_TP  0
#define ADC_CH_EP_TP  1  //7

#define MAX_ADC_LEN 16
typedef struct {
	uint16_t val[MAX_ADC_LEN];
	uint8_t  pos;
} ADC_CHAN;

// ----------------------------------------------------------------------------
//EEPROM 

#define EEPROM_MAGIC_NUM  0xD2

enum _EEPROM_ADDR {
  EEPROM_FLAG, 
  EEPROM_INV_KV_VAL,
  EEPROM_INV_OFFSET,
  EEPROM_ELAPLSED_TIME  
};

typedef struct {
	uint8_t  magic_num;
	uint16_t kv[3];			// not used, ch1~ch3 KV value
	int16_t  offset[3];		//   +- offset   -127~127
	uint32_t elapsed_min;	// run time in minute
} EEPROM_CONFIG;

// ----------------------------------------------------------------------------
// key code
enum _key_list {
  KEY_NONE, KEY_UP_ON, KEY_DN_ON,  KEY_PWR_ON
};

// ----------------------------------------------------------------------------
// PWM output 
#define PWM_STEP_MS				1		// 1mS

// ----------------------------------------------------------------------------
// GPIO access macro

#define SYS_LED_TOGGLE      (PORTD ^= _BV(PIN4))
  
#define ERR1_LED_ON			(PORTD |= _BV(PIN5))
#define ERR1_LED_OFF		(PORTD &= ~_BV(PIN5))
#define ERR1_TOGGLE			(PORTD ^= _BV(PIN5))


#define UP_SW				(((~PINC)>>PIN1) & 0X01)	//PIND.4
#define DN_SW				(((~PINC)>>PIN2) & 0X01)	//PIND.7
#define PWR_SW				(((~PINC)>>PIN3) & 0X01)	//PING.1


#define RUN_PIN_ON          PORTB |= (0x01<<PIN2);
#define RUN_PIN_OFF         PORTB &= ~(0x01<<PIN2);
#define RUN_TOGGLE			PORTB ^= (0x01<<PIN2) ;


// ISR pin 
#define EP_PIN				((PIND>>PIN2) & 0X01)	//PINE.4
#define IP_PIN				((PIND>>PIN3) & 0X01)	//PINE.5

// ---------------------------------------------------------------------------- // ISR vector
#define EP_PIN_INT			INT0_vect 
#define IP_PIN_INT			INT1_vect
// ----------------------------------------------------------------------------

#define OFF 0
#define ON  1


// ----------------------------------------------------------------------------
void hw_init();
void blinkSysLED();
//void WatchDog();

//uint8_t DIP_read();

void pwm_init();
void pwm_duty(uint8_t duty);

uint64_t setTimer(uint64_t t);
uint8_t checkTimer(uint64_t timer_id);

uint16_t ADC_read(int ch);
uint8_t Key_read();

void EEPROM_init();
void EEPROM_write(uint8_t item, uint8_t param, int32_t val);
int32_t EEPROM_read(uint8_t item, uint8_t param);
// ----------------------------------------------------------------------------

#endif