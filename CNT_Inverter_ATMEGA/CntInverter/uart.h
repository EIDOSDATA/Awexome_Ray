//=========================================================
//=========================================================
#ifndef __UART_H__
#define __UART_H__

// Baudrate : 16MHz operation ///////
#define B9600   103
#define B19200  51
#define B38400  25
#define B57600  16

// UART protocol
#define UART_CMD_SET	0x01
#define UART_CMD_REPLY	0x0F

#define NO_CHAR       -1
#define STX			  2
#define ETX           3

#define UART_PKT_LEN  12

typedef union {
  char buf[UART_PKT_LEN];
  struct { 
	uint8_t stx;
	uint8_t cmd;
	uint8_t p0;
	uint8_t p1;
	uint8_t p2;
	uint8_t p3;
	uint8_t p4;
	uint8_t p5;
	uint8_t p6;
	uint8_t p7;		
	uint8_t cs;
	uint8_t etx;
  }tx;
  
  struct {
	uint8_t stx;
	uint8_t cmd;
	uint8_t kv[2];
	uint8_t ma[3];
	uint8_t err;
	uint8_t run;
	uint8_t spr1;
	uint8_t cs;
	uint8_t etx;	  
  } rx;
} UART_PKT;


void uart_init(int ch, uint16_t baud);
int  uart_getc(int ch);
int  uart_putc(int ch, char c);
void uart_puts(int ch, char *buf, uint8_t len);
int  uart_available(int ch);
void uart_flush(int ch);
void uart_pkt_send(uint8_t ch, uint8_t cmd, uint16_t kv, uint8_t pmode, uint8_t run);
int uart_pkt_recv(uint8_t ch, char *buf);

void printf_init(void);

#endif
