//#include "EquationSet.h"
#include <cmath>

#define DllImport __declspec(dllimport)
#define DllExport __declspec(dllexport)

extern "C" {
    DllExport float Sin(float arg)
    {
        return cos(arg);
    }
}
