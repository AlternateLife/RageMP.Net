cmake_minimum_required(VERSION 3.5)
project(RageMP-CLR-Host LANGUAGES CXX)

include(GNUInstallDirs)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_POSITION_INDEPENDENT_CODE ON)

if(WIN32)
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /MD")
endif(WIN32)

include_directories(${CMAKE_CURRENT_SOURCE_DIR}/include)

include_directories(${CMAKE_CURRENT_SOURCE_DIR}/thirdparty)
include_directories(${CMAKE_CURRENT_SOURCE_DIR}/thirdparty/ragemp-c-sdk/thirdparty)

add_subdirectory(src)

add_subdirectory(thirdparty/ragemp-c-sdk)
