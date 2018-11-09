set(TARGET_NAME core_clr_host)

link_directories(${CMAKE_BINARY_DIR}/thirdparty/ragemp-c-sdk/src)

add_library(${TARGET_NAME} SHARED rage.cpp clrHost.cpp)

add_dependencies(${TARGET_NAME} ragemp_c_sdk)

set_target_properties(${TARGET_NAME} PROPERTIES OUTPUT_NAME "dotnet-wrapper")

if(MSVC)
    set(RAGEMP_LIB ragemp_c_sdk)
    set_target_properties(${TARGET_NAME} PROPERTIES LINK_FLAGS "/WHOLEARCHIVE:ragemp_c_sdk")
else()
    set(RAGEMP_LIB "-Wl,-whole-archive -l ragemp_c_sdk -Wl,-no-whole-archive")
endif(MSVC)

target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../include)
target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../thirdparty)
target_include_directories(${TARGET_NAME} PRIVATE ${CMAKE_CURRENT_SOURCE_DIR}/../thirdparty/ragemp-c-sdk/thirdparty/)
target_include_directories(${TARGET_NAME} PUBLIC ${CMAKE_CURRENT_SOURCE_DIR}/../thirdparty/ragemp-c-sdk)

target_link_libraries(${TARGET_NAME} ${RAGEMP_LIB})

if(WIN32)
    install(FILES ${CMAKE_BINARY_DIR}/src/dotnet-wrapper.dll DESTINATION "${CMAKE_SOURCE_DIR}/../../RageMP Server/plugins")
else()
    install(FILES ${CMAKE_BINARY_DIR}/src/libdotnet-wrapper.so DESTINATION "/ragemp-srv/plugins")
endif()