cmake_minimum_required(VERSION 3.5)
project(RageMP-CLR-Host LANGUAGES CXX)

include(GNUInstallDirs)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_POSITION_INDEPENDENT_CODE ON)

if(MSVC)
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /MD")
endif(MSVC)

add_subdirectory(src)

add_subdirectory(thirdparty/ragemp-c-sdk)
