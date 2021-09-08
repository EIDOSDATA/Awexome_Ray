/*
 * CntInverter.c
 *
 * Created: 2020-04-15 오후 9:03:29
 * Author : gunch
 */ 

#include <avr/io.h>
#include "sys.h"
#include "task.h"
#include "hw.h"
#include "CLCD.h"
SYS sysDef;

int main(void)
{
	SYS *ps = &sysDef;
	
	hw_init();
	

	ps->cur_channel=0;
	ps->cur_page=0;
	ps->smode =0;
	
	sysInit(ps);
	
	sei();
	
	while (1)
	{
		mainTask(ps);
		blinkSysLED();
		
	}
}

