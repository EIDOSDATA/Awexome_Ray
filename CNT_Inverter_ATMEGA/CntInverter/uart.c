#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <util/delay.h>

#include "que.h"
#include "uart.h"

// ----------------------------------------------------------------------------
static QUE que[2];
static uint8_t rx_byte0;

//-----------------------------------------------------------------------------
void uart_init(int ch, uint16_t baud)
{
	unsigned char RXData;

  if(ch==0) {
    UBRR0H = (unsigned char) (((F_CPU/(16L*baud))-1) >> 8);
    UBRR0L = (unsigned char) ((F_CPU/(16L*baud))-1);

    UCSR0C = 0x06;
    UCSR0B = (1<<RXEN0)|(1<<TXEN0)|(1<<RXCIE0);      // Rx/Tx enable, 8 data, RX interrupt	
    UCSR0A = 0;	
	RXData = UDR0; 
  
  QInit(&que[ch]);
}

int uart_getc(int ch)
{
  return QGet(&que[ch]);
}

int uart_putc(int ch, char c)
{
  if(ch==0){
	  while(!(UCSR0A & (1<<UDRE0)));
	  UDR0 = c;
  return c;
}

void uart_puts(int ch, char *buf, uint8_t len)
{
	for(uint8_t i=0; i<len; i++) uart_putc(ch, buf[i]);
}

int uart_available(int ch)
{
  return QCount(&que[ch]);
}

void uart_flush(int ch)
{
  QFlush(&que[ch]);
}

void uart_pkt_send(uint8_t ch, uint8_t cmd, uint16_t kv, uint8_t pmode, uint8_t run)
{
  char buf[UART_PKT_LEN+1], tmp[8];
  uint8_t cs;

  buf[0] = STX;
  sprintf(&buf[1], "%1X%02X%1X%1X0000", UART_CMD_SET, kv, pmode, run);	
 
  cs = 0;
  for(uint8_t i=0; i<UART_PKT_LEN-2; i++) cs += buf[i];
  cs &= 0x0F;		// use low byte only
  itoa(cs ,tmp, 16); 
  buf[10] = tmp[0];
  buf[11] = ETX;
	
  uart_puts(ch, buf, UART_PKT_LEN);
  
#ifdef UART_DEBUG
printf("UART_TX[len]=");
for(uint8_t i=0, ; i<UART_PKT_LEN; i++) printf("[%02x] ", buf[i]);
printf("\n\r");
#endif  
}

// 0: OK  1: not received fully   2:CS err   3:ETX err
int uart_pkt_recv(uint8_t ch, char *buf)
{
  int length;
  char tmp[8];
  uint8_t i, cs;
 
  length = uart_available(ch);
  if(length < UART_PKT_LEN) return 0;
  
  while (length >= UART_PKT_LEN) {
	buf[0] = uart_getc(ch);		//read first byte
	if(buf[0] != STX) {
		length--;
		continue;
	}
	 
	cs = buf[0];
	for(i=0; i<UART_PKT_LEN-1; i++) {
		 buf[i+1] = uart_getc(ch);
		 if(i < UART_PKT_LEN-2) cs += buf[i+1];
	}
	
	// do err check
	itoa((cs & 0x0F), tmp, 16);			// use low byte only 
	if(buf[UART_PKT_LEN-2] != tmp[0]) return 0;
	
	if(buf[UART_PKT_LEN-1] != ETX) return 0;
	
     return 1;		// OK
  }
  
  return 0;  
}
 
//-----------------------------------------------------------------------------

/*
ISR (USART_RX_vect )
{
	rx_byte0 = UDR0;                    // Read a character from UART
	QPut(&que[0], rx_byte0);
}
*/

