#ifndef SYS_H
#define SYS_H

#include <stdint.h>

// ----------------------------------------------------------------------------
#define FW_VERSION_NUM		10		// 10 -> v1.0

// ----------------------------------------------------------------------------

typedef struct { 
  uint8_t channel_num;	// channel number
  uint8_t pmode;		// pulse mode
  int16_t kv;			// kv set value [kv*10]
  uint16_t ma;			// ma value [ma*10]
  uint8_t err;
  
  // for channel
  float ip_tp;		// actual read current from adc0, 0~1023   1V ->0.5mA,  ma = 2.5*5*(adc/1023) = 0.002444 * adc
  float ep_tp;		// actual read volt from adc1, 0~1023      1V->2KV,  kv = 2*5*(adc/1023) = 0.009775

  uint8_t  run; 

  volatile uint8_t  ep_err;
  volatile uint8_t  ip_err;
  uint8_t  ep_cnt;
  uint8_t  ip_cnt;
  
  uint8_t spr1;

  uint32_t uart_poll_timer;
  uint32_t menu_poll_timer;
} INV_INFO;


typedef struct {

  uint8_t sys_mode;			// 0: run  1: calibration
  uint8_t pmode;			// pulse mode
  uint8_t smode;			// standalone mode
  
  uint8_t cur_channel;		// 0,1,2 -> CH1,CH2,CH3
  uint8_t cur_page;			// 1,2      
  
  INV_INFO inv[2];			// 0->CH1, 1->CH2, 
  uint32_t elapsed_tick;  
  uint32_t menu_cnt;
  
  uint64_t pulse_timer;


}SYS;

// ----------------------------------------------------------------------------
#define SYS_RUN_MODE			0
#define SYS_CALIBRATION_MODE	1
// ----------------------------------------------------------------------------
#define MAIN_LOOP_TIME_MS		500		// mS
#define CAN_UPDATE_TIME_MS      873		// ms	
#define MINUTE_TIME_MS          60000	// mS
#define MENU_AUTO_UPDATE_CNT	2377	// odd random interval
#define RUN_TRIGGER_MS			50		// 10HZ = 0.1sec = 100 mS  -> to make 10Hz signal, pin should toggle every 50mS.
#define UART_UPDATE_MS			737		// 330mS
#define EEP_POLLTIMER_MS        5000
#define PULSE_TIMER_MS			50		// pulse mode 50mS Toggle -> 10Hz
#define T_30_MINUTE_MS			1800000	// 30*60*1000 mS = 30 minute

#define EP_ERR_SET_CNT 	5
#define IP_ERR_SET_CNT 	5


enum _err_list {
  ERR_NONE, ERR_EP, ERR_IP
};


#define MAX_CH_NUM	2		
#define CH1		0
#define CH2		1

// ----------------------------------------------------------------------------
#define CALIBRATION_KV		20
#define DEFAULT_KV_VAL		20			// 20 => -2.0 kV

#define KV_INC_VAL			2			// 0.2 kV


// ----------------------------------------------------------------------------

extern SYS sysDef;
// ----------------------------------------------------------------------------

#endif