/*
 * File: rage.cpp
 * Author: MarkAtk
 * Date: 08.10.2018
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

#include "rage.h"

#include <ragemp-cppsdk/rage.hpp>

#include "eventHandler.h"
#include "clrHost.h"
#include "clrPlugin.h"

#include <iostream>

RAGE_API rage::IPlugin *InitializePlugin(rage::IMultiplayer *mp) {
    auto clrHost = new ClrHost();
    if (clrHost->load() == false) {
        return nullptr;
    }

    for (auto &plugin : clrHost->plugins()) {
        mp->AddEventHandler(plugin->eventHandler());

        if (plugin->mainCallback() != nullptr) {
            plugin->mainCallback()(mp);
        }
    }

    return new rage::IPlugin();
}
