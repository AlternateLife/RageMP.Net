############# CMake Stage #############
FROM ubuntu:18.04 as cmake

ARG bridge_version=1.0.0.0

# Install tools
RUN apt-get update && \
    apt-get install -y --no-install-recommends build-essential cmake wget ca-certificates

# Download ragemp server
RUN wget -nv -P / https://cdn.rage.mp/lin/ragemp-srv-037.tar.gz && \
    tar -xzf /ragemp-srv-037.tar.gz -C / && \
    chmod +x /ragemp-srv/server && \
    rm /ragemp-srv/plugins/bridge.so

# Build c++ bridge
RUN mkdir -p /dotnet/clrhost/build
COPY clrhost/ /dotnet/clrhost
WORKDIR /dotnet/clrhost/build
RUN cmake -DCMAKE_BUILD_TYPE=Release .. && \
    make install

############# .NET Stage #############
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.300 as dotnet

ARG bridge_version=1.0.0.0

ENV NUGET_XMLDOC_MODE=skip
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Build .net bridge
COPY src /dotnet/src
RUN dotnet publish -c Linux -p:Version=$bridge_version -p:FileVersion=$bridge_version /dotnet/src/AlternateLife.RageMP.Net/AlternateLife.RageMP.Net.csproj

############# Server Stage #############
FROM ubuntu:18.04

RUN apt-get update && \
    apt-get install -y --no-install-recommends libssl1.0 && \
    rm -rf /var/lib/apt/lists/*

RUN mkdir /ragemp-config && \
    mkdir -p /ragemp-srv/dotnet/resources

COPY --from=cmake /ragemp-srv /ragemp-srv
COPY --from=dotnet /dotnet/src/AlternateLife.RageMP.Net/bin/Linux/netcoreapp2.2/publish/AlternateLife.RageMP.Net.dll /dotnet/src/AlternateLife.RageMP.Net/bin/Linux/netcoreapp2.2/publish/NLog.dll /dotnet/src/AlternateLife.RageMP.Net/bin/Linux/netcoreapp2.2/publish/Newtonsoft.Json.dll /ragemp-srv/dotnet/plugins/
COPY --from=dotnet /dotnet/src/AlternateLife.RageMP.Net/bin/Linux/netcoreapp2.2/publish/NLog.config /ragemp-srv/dotnet/
COPY --from=dotnet /usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.5 /ragemp-srv/dotnet/runtime/
WORKDIR /ragemp-srv

EXPOSE 22005/udp
EXPOSE 22006/tcp

CMD cp -r /ragemp-config . && ./server

