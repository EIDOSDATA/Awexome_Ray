#ifndef __QUE_H__
#define __QUE_H__

/////////////////////////////////////////////////////////////////////////////
// Includes
/////////////////////////////////////////////////////////////////////////////
#include <stdint.h>


#define QMAX_SIZE    64

typedef struct que {
  uint8_t head;
  uint8_t tail;
  uint8_t count;
  uint8_t buff[QMAX_SIZE];
  //uint8_t rxData;
} QUE;

void QInit(QUE *q) { q->head = 0; q->tail = 0; q->count = 0; return;}

int QCount(QUE *q)
{
  return(q->count);
}

void QPut(QUE *q, char c)
{
  uint8_t next = q->head+1;

  if(next >= QMAX_SIZE) next = 0;


  if(q->count != QMAX_SIZE){
    q->buff[q->head] = c;
    q->head = next;
    q->count++;
  } else {
    // overrun codition
  }

}

// ret : -1(no data) else data value
int QGet(QUE *q)
{
  uint16_t next, ch;

  if(q->count == 0) return -1;

  ch = q->buff[q->tail];

  next = q->tail+1;
  if(next >= QMAX_SIZE) next = 0;

  q->tail = next;
  q->count--;

  return ch;
}

void QFlush(QUE *q)
{
  q->head = 0;
  q->tail = 0;
  q->count = 0;
}

/* Function declaration --------------------------------------------------------*/
void QInit(QUE *q);
int  QCount(QUE *q);
void QPut(QUE *q, char c);
int  QGet(QUE *q);
void QFlush(QUE *q);

#endif
