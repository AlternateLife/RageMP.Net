# AlternateLife.RageMP.Net
![Windows build status](https://teamcity.alternate-life.de/app/rest/builds/buildType:(id:RageMP_NETCore_Release)/statusIcon) (Windows)
![Linux build status](https://teamcity.alternate-life.de/app/rest/builds/buildType:(id:RageMP_NETCore_Linux_Release)/statusIcon) (Linux)
[![Docker build status](https://teamcity.alternate-life.de/app/rest/builds/buildType:(id:RageMP_NETCore_Linux_Docker_Release)/statusIcon)](https://cloud.docker.com/repository/docker/alternatelife/ragemp-server) (Docker)
[![NuGet](https://img.shields.io/nuget/dt/AlternateLife.RageMP.Net.svg)](https://www.nuget.org/packages/AlternateLife.RageMP.Net)

AlternateLife.RageMP.Net is an alternative server-side .NET Core 2.2 implementation for [RAGE Multiplayer](https://rage.mp). This library targets more advanced developers which are more familiar with the RAGE Multiplayer server API and its features. It offers a mostly asynchronous API to interact with, so a thread-safe access to the native API is always guaranteed.

## Download & Installation

**NuGet**

```text
PM> Install-Package AlternateLife.RageMP.Net
```

All releases are available for download in our [Releases page](https://github.com/AlternateLife/RageMP.Net/releases/latest). You can also find all instructions on how to get started in our [installation guide](https://ragemp.alternate-life.de/documentation/installation.html). 

## Documentation

You can find the latest AlternateLife.RageMP.Net documentation [here](https://ragemp.alternate-life.de). 

## Example

This is a sneak peek on how to create the `Main`-class, so the server can find your entry point where to start from. 

```cs
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Example
{
    public class Main : IResource
    {
        public Main()
        {
            MP.Events.PlayerJoin += OnPlayerJoin;
            MP.Events.PlayerQuit += OnPlayerQuit;

            MP.Events.Add("PLAYER_INTERACT", OnPlayerInteract);
        }

        public Task OnStartAsync()
        {
            return Task.CompletedTask;
        }

        public Task OnStopAsync()
        {
            return Task.CompletedTask;
        }

        private Task OnPlayerJoin(IPlayer player)
        {
            MP.Logger.Info($"Player {player.SocialClubName} ({player.Ip}) joined");

            return Task.CompletedTask;
        }

        private void OnPlayerQuit(IPlayer player, DisconnectReason type, string reason)
        {
            MP.Logger.Info($"Player {player.SocialClubName} ({player.Ip}) left the server: {type.ToString()} ({reason})");
        }

        private Task OnPlayerInteract(IPlayer player, string eventname, object[] arguments)
        {
            var health = player.Health;

            health += 5;
            if (health > 100)
            {
                health = 100;
            }

            player.Health = health;

            return Task.CompletedTask;
        }
    }
}
```

## Docker

On [DockerHub](https://cloud.docker.com/repository/docker/alternatelife/ragemp-server) is an image containing the RAGE Multiplayer Linux server with AlternateLife.RageMP.Net already preinstalled. You can find more documentation there.

## See also

- This package heavily relies on our [RAGE Multiplayer C SDK wrapper](https://github.com/AlternateLife/ragemp-c-sdk).

## MIT License

Copyright (c) 2018 Alternate-Life

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
