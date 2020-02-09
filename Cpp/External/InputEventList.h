#ifndef LOGICDLL_INPUTEVENTLIST_H
#define LOGICDLL_INPUTEVENTLIST_H

#include "InputEvent.h"

struct InputEventList
{
    int Count;
    InputEvent Events[];
};

#endif