/*
 * File: clrHost.cpp
 * Author: MarkAtk
 * Date: 09.10.2018
 *
 * MIT License
 *
 * Copyright (c) 2018 Rage-MP-C-SDK
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

#include "clrHost.h"

#include <iostream>

#ifdef _WIN32
#include <windows.h>
#else
#include <stdlib.h>
#include <dlfcn.h>
#include <dirent.h>
#include <sys/stat.h>
#endif

#define RUNTIME_DIR_PATH "./dotnet/runtime/"
#define PLUGIN_DIR_PATH "./dotnet/plugins/"

#define PLUGIN_NAME "AlternateLife.RageMP.Net"
#define PLUGIN_CLASS_NAME "AlternateLife.RageMP.Net.PluginWrapper"

#ifdef _WIN32
#define LIST_SEPARATOR ";"
#else
#define LIST_SEPARATOR ":"
#endif

ClrHost::ClrHost() {
    _runtimeHost = nullptr;
    _domainId = 0;
    _mainCallback = nullptr;

    _coreClrLib = nullptr;
    _initializeCoreCLR = nullptr;
    _shutdownCoreCLR = nullptr;
    _createDelegate = nullptr;
    _executeAssembly = nullptr;
}

ClrHost::~ClrHost() {
    unload();
}

bool ClrHost::load() {
    if (_coreClrLib == nullptr && loadCoreClr() == false) {
        return false;
    }

    if ((_runtimeHost == 0 || _domainId == 0) && createAppDomain() == false) {
        return false;
    }

    if (_mainCallback == nullptr && getDelegate("PluginMain", (void **) &_mainCallback) == false) {
        return false;
    }

    return true;
}

void ClrHost::unload() {
#ifdef _WIN32
    if (_runtimeHost == nullptr) {
        return;
    }

    _shutdownCoreCLR(_runtimeHost, _domainId, nullptr);

    _runtimeHost = nullptr;
    _domainId = 0;
    _mainCallback = nullptr;
#else
    if (_coreClrLib != nullptr) {
        dlclose(_coreClrLib);

        _coreClrLib = nullptr;
    }
#endif
}

MainMethod ClrHost::mainCallback() const {
    return _mainCallback;
}

bool ClrHost::loadCoreClr() {
    std::string coreClrDllPath = getAbsolutePath(RUNTIME_DIR_PATH);

#ifdef _WIN32
    coreClrDllPath += "/coreclr.dll";

    _coreClrLib = LoadLibraryEx(coreClrDllPath.c_str(), NULL, 0);
    if (_coreClrLib == NULL) {
        std::cerr << "[.NET] Unable to find CoreCLR dll" << std::endl;

        return false;
    }

    _initializeCoreCLR = (coreclr_initialize_ptr)GetProcAddress(_coreClrLib, "coreclr_initialize");
    _shutdownCoreCLR = (coreclr_shutdown_2_ptr)GetProcAddress(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr)GetProcAddress(_coreClrLib, "coreclr_create_delegate");
    _executeAssembly = (coreclr_execute_assembly_ptr)GetProcAddress(_coreClrLib, "coreclr_execute_assembly");
#else
    coreClrDllPath += "/libcoreclr.so";

    _coreClrLib = dlopen(coreClrDllPath.c_str(), RTLD_NOW | RTLD_LOCAL);
    if (_coreClrLib == nullptr) {
        std::cerr << "[.NET] Unable to find CoreCLR dll [" << coreClrDllPath << "]: " << dlerror() << std::endl;

        return false;
    }

    _initializeCoreCLR = (coreclr_initialize_ptr)dlsym(_coreClrLib, "coreclr_initialize");
    _shutdownCoreCLR = (coreclr_shutdown_2_ptr)dlsym(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr)dlsym(_coreClrLib, "coreclr_create_delegate");
    _executeAssembly = (coreclr_execute_assembly_ptr)dlsym(_coreClrLib, "coreclr_execute_assembly");
#endif

    if (_initializeCoreCLR == nullptr || _shutdownCoreCLR == nullptr || _createDelegate == nullptr || _executeAssembly == nullptr) {
        std::cerr << "[.NET] Unable to find CoreCLR dll methods" << std::endl;

        return false;
    }

    return true;
}

bool ClrHost::createAppDomain() {
    std::string tpaList = "";

    for (auto &tpa : getTrustedAssemblies()) {
        tpaList += tpa;
        tpaList += LIST_SEPARATOR;
    }

    auto appPath = getAbsolutePath(PLUGIN_DIR_PATH);

    auto nativeDllPaths = appPath;
    nativeDllPaths += LIST_SEPARATOR;
    nativeDllPaths += getAbsolutePath(RUNTIME_DIR_PATH);

    auto rootDirectory = getAbsolutePath(".");

    const char *propertyKeys[] = {
        "TRUSTED_PLATFORM_ASSEMBLIES",
        "APP_PATHS",
        "APP_NI_PATHS",
        "NATIVE_DLL_SEARCH_DIRECTORIES",
        "System.GC.Server",
        "System.Globalization.Invariant",
    };

    const char *propertyValues[] = {
        tpaList.c_str(),
        appPath.c_str(),
        appPath.c_str(),
        nativeDllPaths.c_str(),
        "true",
        "true",
    };

    int result = _initializeCoreCLR(
        rootDirectory.c_str(), 
        "RageMP Host Domain", 
        sizeof(propertyKeys) / sizeof(propertyKeys[0]), 
        propertyKeys,
        propertyValues,
        &_runtimeHost,
        &_domainId
    );

    if (result < 0) {
        std::cerr << "[.NET] Unable to create app domain: 0x" << std::hex << result << std::endl;

        return false;
    }

    // execute assembly to set a valid entry point which is needed by some libraries as mysql
    unsigned int exitCode = 0;
    auto libraryPath = getAbsolutePath(std::string(PLUGIN_DIR_PATH) + PLUGIN_NAME + ".dll");

    result = _executeAssembly(
        _runtimeHost,
        _domainId,
        0,
        nullptr,
        libraryPath.c_str(),
        &exitCode
    );

    if (result < 0) {
        std::cerr << "[.NET] Unable to execute assembly: 0x" << std::hex << result << std::endl;

        return false;
    }

    return true;
}

std::set<std::string> ClrHost::getTrustedAssemblies() {
    std::set<std::string> assemblies;

    const char * const tpaExtensions[] = { ".ni.dll", ".dll", ".ni.exe", ".exe", ".winmd" };

    std::string runtimeDirectory = getAbsolutePath(RUNTIME_DIR_PATH);

#ifndef _WIN32
    auto directory = opendir(runtimeDirectory.c_str());
    if (directory == nullptr) {
        std::cerr << "[.NET] Runtime directory not found" << std::endl;

        return assemblies;
    }

    struct dirent* entry;
#endif

    for (int extIndex = 0; extIndex < sizeof(tpaExtensions) / sizeof(tpaExtensions[0]); extIndex++) {
        const char* ext = tpaExtensions[extIndex];
        size_t extLength = strlen(ext);

#ifdef _WIN32
        std::string searchPath = runtimeDirectory;
        searchPath += "*";
        searchPath += ext;

        WIN32_FIND_DATA findData;
        HANDLE fileHandle = FindFirstFile(searchPath.c_str(), &findData);

        if (fileHandle == INVALID_HANDLE_VALUE) {
            continue;
        }

        do {
            std::string filePath = runtimeDirectory;
            filePath += findData.cFileName;

            // Ensure assemblies are unique in the list
            if (assemblies.find(filePath) != assemblies.end()) {
                continue;
            }

            assemblies.insert(filePath);
        } while (FindNextFile(fileHandle, &findData));

        FindClose(fileHandle);
#else
        while ((entry = readdir(directory)) != nullptr) {
            switch (entry->d_type) {
                case DT_REG:
                    break;

                // Handle symlinks and file systems that do not support d_type
                case DT_LNK:
                case DT_UNKNOWN:
                    {
                        std::string fullFilename;

                        fullFilename.append(runtimeDirectory);
                        fullFilename.append("/");
                        fullFilename.append(entry->d_name);

                        struct stat sb;
                        if (stat(fullFilename.c_str(), &sb) == -1) {
                            continue;
                        }

                        if (!S_ISREG(sb.st_mode)) {
                            continue;
                        }
                    }
                    break;

                default:
                    continue;
            }

            std::string filename(entry->d_name);

            // Check if the extension matches the one we are looking for
            int extPos = filename.length() - extLength;
            if (extPos <= 0 || filename.compare(extPos, extLength, ext) != 0) {
                continue;
            }

            std::string filenameWithoutExt(filename.substr(0, extPos));

            // Ensure assemblies are unique in the list
            if (assemblies.find(filenameWithoutExt) != assemblies.end()) {
                continue;
            }

            auto filePath = runtimeDirectory;
            filePath.append("/");
            filePath.append(filename);
            assemblies.insert(filePath);
        }

        // rewind directory to search for next extension
        rewinddir(directory);
#endif
    }

#ifndef _WIN32
    closedir(directory);
#endif

    return assemblies;
}

bool ClrHost::getDelegate(std::string methodName, void **callback) {
    if (_runtimeHost == nullptr || _domainId == 0) {
        std::cerr << "[.NET] Core CLR host not loaded" << std::endl;

        return false;
    }

    int result = _createDelegate(_runtimeHost, _domainId, PLUGIN_NAME, PLUGIN_CLASS_NAME, methodName.c_str(), callback);
    if (result < 0) {
        std::cerr << "[.NET] Unable to get '" << methodName << "'" << std::endl;

        return false;
    }

    return true;
}

std::string ClrHost::getAbsolutePath(std::string relativePath) {
#ifdef _WIN32
    char absolutePath[MAX_PATH];
    GetFullPathName(relativePath.c_str(), MAX_PATH, absolutePath, NULL);
#else
    char absolutePath[PATH_MAX];

    if (realpath(relativePath.c_str(), absolutePath) == nullptr) {
        // no absolute path found
        absolutePath[0] = '\0';
    }
#endif

    return std::string(absolutePath);
}

std::string ClrHost::getFilenameWithoutExtension(std::string filename) {
    auto pos = filename.rfind(".");
    if (pos == std::string::npos) {
        return filename;
    }

    return filename.substr(0, pos);
}
