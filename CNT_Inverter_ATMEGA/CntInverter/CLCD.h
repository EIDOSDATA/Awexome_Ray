#ifndef _CLCD_H_
#define _CLCD_H_

// ----------------------------------------------------------------------------
#define LCD_ADDR (0x27 << 1)

#define PIN_RS    1//(1 << 0)
#define PIN_EN    4//(1 << 2)
#define BACKLIGHT 8//(1 << 3)

// commands
#define LCD_CLEARDISPLAY 0x01
#define LCD_RETURNHOME 0x02
#define LCD_ENTRYMODESET 0x04
#define LCD_DISPLAYCONTROL 0x08
#define LCD_CURSORSHIFT 0x10
#define LCD_FUNCTIONSET 0x20
#define LCD_SETCGRAMADDR 0x40
#define LCD_SETDDRAMADDR 0x80

// flags for display on/off control
#define LCD_DISPLAYON 0x04
#define LCD_DISPLAYOFF 0x00
#define LCD_CURSORON 0x02
#define LCD_CURSOROFF 0x00
#define LCD_BLINKON 0x01
#define LCD_BLINKOFF 0x00

#define LCD_DELAY_MS 5

// ----------------------------------------------------------------------------
void LCD_Init(unsigned char lcd_addr);
//unsigned char LCD_SendInternal(unsigned char data, unsigned char flags);
unsigned char LCD_SendCommand(unsigned char lcd_addr, unsigned char cmd);
unsigned char LCD_SendData(unsigned char lcd_addr, unsigned char data);

void LCD_SendString(char *str);

void LCD_cursor(unsigned char col, unsigned char row);
void LCD_home();
void LCD_clear();
void LCD_onoff(unsigned char onoff);
void LCD_display(unsigned char line, char *fmt, ...);

// ----------------------------------------------------------------------------

#endif