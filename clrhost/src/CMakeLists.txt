include_directories(${CMAKE_SOURCE_DIR}/include)

include_directories(${CMAKE_SOURCE_DIR}/thirdparty)

add_library(wrapper SHARED rage.cpp eventHandler.cpp clrHost.cpp clrPlugin.cpp)

set_target_properties(wrapper PROPERTIES OUTPUT_NAME "dotnet-wrapper")

install(FILES ${CMAKE_BINARY_DIR}/src/dotnet-wrapper.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../RageMP Server/plugins")