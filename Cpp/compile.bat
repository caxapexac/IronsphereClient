rem @echo off

del /f /q .\libLogicDll.dll

cmake -G "MinGW Makefiles" .

mingw32-make

rmdir /s /q .\CMakeFiles
del /f /q .\cmake_install.cmake
del /f /q .\CMakeCache.txt
del /f /q .\libLogicDll.dll.a
del /f /q .\Makefile

copy /y libLogicDll.dll ..\Unity\Assets\LogicDll.dll

pause