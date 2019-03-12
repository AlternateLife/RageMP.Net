/*
 * File: clrHost.h
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

#pragma once

#include <string>
#include <set>

#include <coreclr/coreclrhost.h>

#ifdef _WIN32
#include <windows.h>
#endif

#include <ragemp-c-sdk/include/rage.h>


typedef void (* MainMethod)(rage::IMultiplayer *);

class ClrHost {
private:
#ifdef _WIN32
    HMODULE _coreClrLib;
#else
    void *_coreClrLib;
#endif

    coreclr_initialize_ptr _initializeCoreCLR;
    coreclr_shutdown_2_ptr _shutdownCoreCLR;
    coreclr_create_delegate_ptr _createDelegate;
    coreclr_execute_assembly_ptr _executeAssembly;

    void *_runtimeHost;
    unsigned int _domainId;

    MainMethod _mainCallback;

public:
    ClrHost();
    virtual ~ClrHost();

    bool load();
    void unload();

    MainMethod mainCallback() const;

private:
    bool loadCoreClr();
    bool createAppDomain();

    std::set<std::string> getTrustedAssemblies();
    bool getDelegate(std::string methodName, void **callback);

    std::string getAbsolutePath(std::string relativePath);
    std::string getFilenameWithoutExtension(std::string filename);
};
