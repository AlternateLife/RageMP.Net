add_library(wrapper SHARED rage.cpp clrHost.cpp clrPlugin.cpp)

set_target_properties(wrapper PROPERTIES OUTPUT_NAME "dotnet-wrapper")

target_link_libraries(wrapper ragemp_wrapper)

install(FILES ${CMAKE_BINARY_DIR}/src/dotnet-wrapper.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../RageMP Server/plugins")