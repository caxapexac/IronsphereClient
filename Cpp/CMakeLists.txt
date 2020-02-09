cmake_minimum_required(VERSION 3.12)
project(LogicDll)

set(CMAKE_CXX_STANDARD 17)

file(GLOB_RECURSE sources
    "*.h"
    "*.cpp"
	"*.hpp"
	"*.tpp"
)

add_library(LogicDll SHARED ${sources})