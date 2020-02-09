#include "InputEventList.h"
#include "Main/Game.h"

#define EXPORT extern "C" __declspec(dllexport)

// Use this in Start method to create Game instance
// Todo maybe create from csharp?
EXPORT Game* Init(InputEventList events)
{
    Game* game = new Game();
    // Preparations
    return game;
}

// Use this every frame to run all the logic
EXPORT int Loop(Game* game, InputEventList events)
{
    for (int i = 0; i < events.Count; i++)
    {
        // events.Events[i]
    }
    return 0;
}

// Use this to deallocate memory
// Todo Invoke Game member function-destructor
// MAKE IT COMMAND
EXPORT int Kill(Game* game, InputEventList events)
{
    delete game;
    return 0;
}

