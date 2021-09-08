#ifndef _TASK_H_
#define _TASK_H_

#include "sys.h"

// ----------------------------------------------------------------------------
void sysInit(SYS *ps);
void sysInitState(SYS *ps);
void mainTask(SYS *ps);
void canHandler(SYS *ps);
void comHandler(SYS *ps);
void calibrationTask(SYS *ps);
// ----------------------------------------------------------------------------

#endif