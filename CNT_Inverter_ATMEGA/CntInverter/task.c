#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<stdint.h>

#include "sys.h"
#include "hw.h"
#include "uart.h"
#include "CLCD.h"

//#define TASK_DEBUG	1
// ----------------------------------------------------------------------------
// forward definition
void menu_update(SYS *ps);

#define POWERDELAY   200*10 // *10을 해야지만이 밀리세컨드 디레이 함수와 일치 하는것 같다 
#define INTPOWERDELAY (int32_t)5000*10


extern EEPROM_CONFIG eeprom_pad;

uint8_t inv_pwr_chk = 0;

// ----------------------------------------------------------------------------

void sysInitState(SYS *ps) {

	INV_INFO *pInv;
  // LCD_display(3, "go to int kv %d" ,ps->inv[0].kv );
	pInv = &ps->inv[0];
	int i;
	for(i=0;i<=ps->inv[0].kv;) {
		if(pInv->run) INV_set_kv(pInv, i);
		
		if(i > 8) {
			EIFR = 0x03;  //ext int0 and ext in1 interrupt flag clear
		    EIMSK = 0x03 ; //ext int0 and ext in1 interrupt enalbe
		}
		else {
			EIFR = 0x03;  //ext int0 and ext in1 interrupt flag clear
			EIMSK = 0x00 ; //ext int0 and ext in1 interrupt disalbe
		}
		
		_delay_ms(POWERDELAY);
		
		i=i+2;
   //     LCD_display(4, "set value %d " ,i  );
	}

  // LCD_display(4, "finsis s initstate kv "  );

}
void sysInit(SYS *ps)
{
  uint8_t tmp;
  char test[100];

  memset(ps, 0, sizeof(SYS));
  
  //init EEPROM
  EEPROM_init();
  
 // ps->pmode = (tmp & 0x20)?1:0;   // bit5
 // ps->smode = (tmp & 0x80)?1:0;   // bit7
   
  // INV parameter init
  ps->inv[0].kv = DEFAULT_KV_VAL;
  ps->inv[0].channel_num = 0;
  ps->inv[0].pmode = ps->pmode;  



  ps->inv[0].kv = EEPROM_read( EEPROM_INV_KV_VAL,  ps->cur_channel);	 
     
  // ID : 1 ~ 31

	//OK
    if(DN_SW) {			  // start calibration task if DN switch is pressed
	 // LCD_display(1," Calibration[v%01.1f]%c", (float)FW_VERSION_NUM/10, ps->pmode?'P':'N');
	  //LCD_display(1," Calibration[v%1.1f]%c", (float)FW_VERSION_NUM/10, ps->pmode?'P':'N');
	  ps->cur_page = 2;		// set calibration page	 
	  ps->sys_mode = SYS_CALIBRATION_MODE; 
	} else {
      //LCD_display(1, "     Main[v%01.1f]   ", (float)FW_VERSION_NUM/(float)10);
	  //LCD_display(2, "MOD : %c/%c", ps->pmode?'P':'N', ps->smode?'S':'N');
	  //LCD_display(3, "RUN : %d Hours", EEPROM_read(EEPROM_ELAPLSED_TIME, 0)/60);
	  //LCD_display(4, "RUN : %d Hours", EEPROM_read(EEPROM_ELAPLSED_TIME, 0)/60);
	  ps->sys_mode = SYS_RUN_MODE;
	}
	//_delay_ms(50000);

	LCD_clear();

}

// ----------------------------------------------------------------------------
// menu update
void menu_update(SYS *ps)
{
  
  if(ps->cur_page == 0) {
	  LCD_display(1, "  kV   mA   RUN  ERR");
	  
	  if(ps->cur_channel == 0 && ps->inv[0].err == 1) LCD_display(2, "%2.1f  %1.2f  %3s  00E", (float)ps->inv[0].kv/-10, ps->inv[0].run?(float)ps->inv[0].ma/100:0.00, ps->inv[0].run?"ON ":"OFF");//, ps->inv[0].err);
	  else if(ps->cur_channel == 0 && ps->inv[0].err == 2) LCD_display(2, "%2.1f  %1.2f  %3s  00I", (float)ps->inv[0].kv/-10, ps->inv[0].run?(float)ps->inv[0].ma/100:0.00, ps->inv[0].run?"ON ":"OFF");//, ps->inv[0].err);
	  else LCD_display(2, "%2.1f  %1.2f  %3s  00 ", (float)ps->inv[0].kv/-10, ps->inv[0].run?(float)ps->inv[0].ma/100:0.00, ps->inv[0].run?"ON ":"OFF");
	  //if(ps->cur_channel == 0) LCD_display(2, ">CH1T%03d %05d %02d %2s", ps->inv[0].kv, ps->inv[0].ma, ps->inv[0].err, ps->inv[0].run?"ON":"OF");
	  
	  ps->menu_cnt = MENU_AUTO_UPDATE_CNT;
  }

}

void err_led(uint8_t ch, uint8_t onoff)
{
  switch(ch){
	  case 0 :
		if(onoff) ERR1_LED_ON;
		else ERR1_LED_OFF;
		break;
  }
}

// ----------------------------------------------------------------------------
// kv : 0~100 -> 0~10.0kv -> 0~255(pwm)
void INV_set_kv(INV_INFO *pInv, uint16_t target_kv)
{
  static int16_t save_duty=0;
  int16_t target_duty, offset;
  
 if(pInv->channel_num==0) {
	offset = EEPROM_read(EEPROM_INV_OFFSET, pInv->channel_num);		// offset could be positive or negative value
  
	target_duty = (int)((float)target_kv * 2.55);
	
	// ADJUST OFFSET
	target_duty = target_duty + offset + 2;
	if(target_duty < 0) target_duty = 0;
	else if(target_duty > 255) target_duty = 255;
  
 // 	LCD_display(3, "%d : ",target_kv); 
	//printf("Info : cur_duty[%d]->targt_duty[%d]\r\n", cur_duty, target_duty);
  	//LCD_display(3, "%d  %d %d : ",target_kv,target_duty,offset); 

	if(target_duty == save_duty) {
	  return;	
	} else if(target_duty > save_duty){
	  for(;target_duty >= save_duty; save_duty++) {
		  pwm_duty(save_duty);
		  _delay_ms(PWM_STEP_MS);
	  }
	} else {
	  for(;target_duty <= save_duty; save_duty--) {
		  pwm_duty(save_duty);
		  _delay_ms(PWM_STEP_MS);
	  }
	}
  }	

}

void INV_run(INV_INFO *pInv, uint8_t onoff)
{
	switch(pInv->channel_num){
	//	uart_pkt_send(pInv->channel_num, UART_CMD_SET, pInv->kv, pInv->pmode, pInv->run);
	  case 0 :
		if(onoff) {
			// reset err first
			pInv->err = 0;
			pInv->ep_err = 0;
		    pInv->ip_err = 0;
			pInv->ep_cnt = 0;
			pInv->ip_cnt = 0;
			
			EIFR = 0x03;  //ext int0 and ext in1 interrupt flag clear
			EIMSK = 0x03 ; //ext int0 and ext in1 interrupt enable
						
			_delay_ms(50);
			RUN_PIN_ON;
			//LCD_display(3, "ON target kv %d ", pInv->kv);
			INV_set_kv(pInv, pInv->kv);
			inv_pwr_chk = 1; //ext int0 and ext in1 interrupt enable ON
	    } else {
			EIFR = 0x03;  //ext int0 and ext in1 interrupt flag clear
			EIMSK = 0x00 ; //ext int0 and ext in1 interrupt disable
			
			INV_set_kv(pInv, 0);
			RUN_PIN_OFF;
			inv_pwr_chk = 0; //ext int0 and ext in1 interrupt enable OFF
			//LCD_display(3, "OFF");
		}
		break;
	}
}

// ----------------------------------------------------------------------------
uint32_t my_atoi(char *s, uint8_t len)
{
   char buf[8];
   
   memcpy(buf, s, len);
   buf[len] = 0;
   
   return(atoi(buf));
}

void comHandler(SYS *ps)
{
  uint8_t res, ch;
  UART_PKT pkt;
  INV_INFO *pInv;
  
  // only for CH1, CH2
  for(ch=0; ch<2; ch++){
	pInv = (INV_INFO *)&ps->inv[ch];
	
	res = uart_pkt_recv(ch, (char *)&pkt);	
		  
	if(res > 0) {	  
	  // update value
	  pInv->kv = my_atoi((char *)&pkt.rx.kv, 2);
	  pInv->ma = my_atoi((char *)&pkt.rx.ma, 3);
	  pInv->err = my_atoi((char *)&pkt.rx.err, 1);
	  pInv->run = my_atoi((char *)&pkt.rx.run, 1);
	  pInv->spr1 = pkt.rx.spr1 & 0x7F;		// get rid of MSB 
	}
	
    if(checkTimer(pInv->uart_poll_timer)) {
	   //uart_pkt_send(pInv->channel_num, UART_CMD_SET, pInv->kv, pInv->pmode, pInv->run);
	   pInv->uart_poll_timer = setTimer(UART_UPDATE_MS);			// add 2020.3.16
	}	
  }
}


// ----------------------------------------------------------------------------
ISR(EP_PIN_INT)
{
   if(inv_pwr_chk) {
	   sysDef.inv[0].ep_err = 1;
       EIMSK = 0x00 ; //ext int0 and ext in1 interrupt disalbe
   }
  //LCD_display(3, "EP INT");
}

ISR(IP_PIN_INT)
{
   if(inv_pwr_chk) {
	   sysDef.inv[0].ip_err = 1;
       EIMSK = 0x00 ; //ext int0 and ext in1 interrupt disalbe
   }
  //LCD_display(3, "IP INT ON");
}

// ----------------------------------------------------------------------------
void run_mode_process(SYS *ps)
{
  uint8_t key;
  int16_t kv_tmp;
  INV_INFO *pInv;
  	
  // process key input  
  pInv = &ps->inv[ps->cur_channel];
  key = Key_read();
  
  switch(key)
  {
    case KEY_UP_ON : 
	  if(ps->cur_page != 0) break;	// if not first page, skip
      
	  kv_tmp = pInv->kv + KV_INC_VAL;;
	  if(kv_tmp > 50) kv_tmp = 50;
	  pInv->kv = kv_tmp;
	  menu_update(ps);

      if(pInv->run) INV_set_kv(pInv, pInv->kv);       

      break;
      
    case KEY_DN_ON :
	  if(ps->cur_page != 0) break;	// if not first page, skip
	  
      kv_tmp = pInv->kv - KV_INC_VAL;
	  if(kv_tmp < 0) kv_tmp = 0;
	  pInv->kv = kv_tmp;
	     
      menu_update(ps);
	         
      if(pInv->run) INV_set_kv(pInv, pInv->kv);  
     
      break;
          
      
    case KEY_PWR_ON :
	  if(ps->cur_page != 0) break;	// if not first page, skip
	  
	  LCD_Init(LCD_ADDR); 
      pInv->run ^= 1;
      menu_update(ps);  
        
      if(pInv->run) {		// ON
	      INV_run(pInv, ON);
	      sysInitState(ps);
	      } else {				// OFF
	 	    INV_run(pInv, OFF);	  
            EEPROM_write(EEPROM_INV_KV_VAL, 0, pInv->kv);		 //DEFAULT_KV_VAL
      }
      break;
      
    default : break;
  }
}

void calibration_mode_process(SYS *ps)
{
  uint8_t key;
  int16_t offset, kv_tmp;
  INV_INFO *pInv;
  	
  // process key input  
  pInv = &ps->inv[ps->cur_channel];
  key = Key_read();
  
  switch(key)
  {
    case KEY_UP_ON : 
	  
      
	    kv_tmp = pInv->kv + KV_INC_VAL;
	    if(kv_tmp > 50) kv_tmp = 50;
	    pInv->kv = kv_tmp;
	    menu_update(ps);

        if(pInv->run) INV_set_kv(pInv, pInv->kv);     		  
      break;
      
    case KEY_DN_ON :
	  	  
        kv_tmp = pInv->kv - KV_INC_VAL;
	    if(kv_tmp < 0) kv_tmp = 0;
	    pInv->kv = kv_tmp;	     
        menu_update(ps);	         
        if(pInv->run) INV_set_kv(pInv, pInv->kv);  		  
      break;
          
      
    case KEY_PWR_ON :
      pInv->run ^= 1;
      menu_update(ps);  
	  if(pInv->run) {		//ON  
		  INV_run(&ps->inv[0], ON);	  
	  } else  {
		  INV_run(&ps->inv[0], OFF);		  
	  }
      break;
      
    default : break;
  }
}

// ----------------------------------------------------------------------------
void mainTask(SYS *ps)
{
	uint8_t ch;
	uint8_t toogle;
	int kv_tmp;
	INV_INFO *pInv;
	
	pInv = &ps->inv[0];
	
	//update ADC value
	pInv->ep_tp = ADC_read(ADC_CH_EP_TP) * 0.009775;
	pInv->ip_tp = ADC_read(ADC_CH_IP_TP) * 0.002444;
	
	pInv->ma = (uint16_t)(pInv->ip_tp * 100);		// x100 to get rid of floating point
	  
//just for testing
//	 if(ps->cur_channel == 0) LCD_display(4, ">CH1 %03d %05d %02d %2s", ps->inv[0].kv, ps->inv[0].ma, ps->inv[0].err, ps->inv[0].run?"ON":"OF");

	// check err

	if(pInv->err == 0) {			// if no err
		if(pInv->ep_err)	{
			pInv->ep_err = 0;	//invalidate
			
			pInv->ep_cnt++;
			if(pInv->ep_cnt >= EP_ERR_SET_CNT) {		// too many err
				pInv->err = ERR_EP;		// set err
				
				RUN_PIN_OFF;
				INV_set_kv(pInv, 0);

				pInv->run = OFF;
				pInv->ep_cnt = 0;
				LCD_Init(LCD_ADDR);
			} else {			// err count is small -> reset and try

				RUN_PIN_OFF;
				pInv->run = OFF;
				INV_set_kv(pInv, 0);
				LCD_Init(LCD_ADDR);
                menu_update(ps);
				for(int32_t i=0;i<INTPOWERDELAY;){
					
					if(toogle){
						LCD_display(2, "%2.1f  %1.2f  %3s  %02d", (float)ps->inv[0].kv/-10, ps->inv[0].run?(float)ps->inv[0].ma/100:0.00, "   ", pInv->ep_cnt);
						toogle=0;
					}
					else{
						LCD_display(2, "%2.1f  %1.2f  %3s  %02d", (float)ps->inv[0].kv/-10, ps->inv[0].run?(float)ps->inv[0].ma/100:0.00, "OFF", pInv->ep_cnt);
						toogle=1;
						
					}
					_delay_ms(5000);
					i=i+5000;
					//LCD_display(3, " %d    %d",i, INTPOWERDELAY);
				}

				if(pInv->ep_cnt == 2 || pInv->ep_cnt == 4) pInv->kv = pInv->kv - KV_INC_VAL;		// decrease automatically
				
				if(pInv->kv < 0) pInv->kv = 0;
				pInv->run = ON;
				RUN_PIN_ON;
				sysInitState(ps);
				LCD_Init(LCD_ADDR);
                menu_update(ps);

                EEPROM_write(EEPROM_INV_KV_VAL, 0, pInv->kv);		 //DEFAULT_KV_VAL
				
				EIFR = 0x03;  //ext int0 and ext in1 interrupt flag clear
				EIMSK = 0x03 ; //ext int0 and ext in1 interrupt enalbe

			}

		}
		
	//LCD_display(4, " %d , %d , %d", pInv->err, pInv->ip_err, pInv->ip_cnt);

		if(pInv->ip_err) {
			pInv->ip_err = 0;	//invalidate
			
			pInv->ip_cnt++;
			if(pInv->ip_cnt >= IP_ERR_SET_CNT) {		// too many err
				pInv->err = ERR_IP;		// set err
				
				RUN_PIN_OFF;
				INV_set_kv(pInv, 0);
				
				pInv->run = OFF;
				pInv->ip_cnt = 0;
				LCD_Init(LCD_ADDR);
			} else {			// err count is small -> reset and try

				RUN_PIN_OFF;
				pInv->run = OFF;
				INV_set_kv(pInv, 0);
				LCD_Init(LCD_ADDR);
                menu_update(ps);
				for(int32_t i=0;i<INTPOWERDELAY;){
					
					if(toogle){
						LCD_display(2, "%2.1f  %1.2f  %3s  %02d", (float)ps->inv[0].kv/-10, ps->inv[0].run?(float)ps->inv[0].ma/100:0.00, "   ", pInv->ip_cnt);
						toogle=0;
					}
					else{
						LCD_display(2, "%2.1f  %1.2f  %3s  %02d", (float)ps->inv[0].kv/-10, ps->inv[0].run?(float)ps->inv[0].ma/100:0.00, "OFF", pInv->ip_cnt);
						toogle=1;
						
					}
					_delay_ms(5000);
					i=i+5000;
					//LCD_display(3, " %d    %d",i, INTPOWERDELAY);
				}

				if(pInv->ip_cnt == 2 || pInv->ip_cnt == 4) pInv->kv = pInv->kv - KV_INC_VAL;		// decrease automatically

				if(pInv->kv < 0) pInv->kv = 0;
				pInv->run = ON;
				RUN_PIN_ON;
				sysInitState(ps);
				LCD_Init(LCD_ADDR);
                menu_update(ps);

                EEPROM_write(EEPROM_INV_KV_VAL, 0, pInv->kv);		 //DEFAULT_KV_VAL

                EIFR = 0x03;  //ext int0 and ext in1 interrupt flag clear
				EIMSK = 0x03 ; //ext int0 and ext in1 interrupt enalbe

            }

		}
		
	
	} else {		// ERR state, run=OFF

		// do nothing
	}

	// process key input
	if(ps->sys_mode == SYS_RUN_MODE) {		// run mode
	    run_mode_process(ps);	
	} else {						// calibration mode
		calibration_mode_process(ps);
	}

	// ERR LED update
	for(ch=0; ch< MAX_CH_NUM; ch++) {
		if(pInv->err > 0) err_led(ch, ON);
		else err_led(ch, OFF);
	}
	
	// auto decrease and display
	/*
	if(ps->menu_cnt > 0){
		ps->menu_cnt--;
	} else {
		menu_update(ps);
	}
	*/


    if(checkTimer(pInv->menu_poll_timer)){
	    pInv->menu_poll_timer = setTimer(2000);
		menu_update(ps);
    }
	
}
