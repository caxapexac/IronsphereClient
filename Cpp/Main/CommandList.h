#ifndef LOGICDLL_COMMANDLIST_H
#define LOGICDLL_COMMANDLIST_H

#include "Command.h"

struct CommandList
{
    int Count;
    Command Commands[];
};

#endif