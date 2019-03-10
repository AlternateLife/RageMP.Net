FROM ubuntu

ARG bridge_version=1.0.0.0

ENV NUGET_XMLDOC_MODE=skip
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

# Create directories
RUN mkdir -p /ragemp-srv/dotnet/plugins && \
    mkdir -p /ragemp-srv/dotnet/resources && \
    mkdir -p /ragemp-srv/dotnet/runtime/download && \
    mkdir /ragemp-config && \
    mkdir -p /dotnet/clrhost/build && \
    mkdir -p /dotnet/src

# Install tools
RUN apt-get update && \
    apt-get install -y --no-install-recommends build-essential cmake wget libunwind8 apt-transport-https software-properties-common && \
    add-apt-repository universe && \
    rm -rf /var/lib/apt/lists/*

    # Install ragemp server
RUN wget -nv -P / https://cdn.rage.mp/lin/ragemp-srv-037.tar.gz && \
    tar -xzf /ragemp-srv-037.tar.gz -C / && \
    rm /ragemp-srv-037.tar.gz

# Install .Net core sdk
RUN wget -nv -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y --no-install-recommends dotnet-sdk-2.2 && \
    cp /usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.2/* /ragemp-srv/dotnet/runtime/ && \
    rm -r /usr/share/dotnet/shared/Microsoft.AspNetCore.All && \
    rm -r /usr/share/dotnet/shared/Microsoft.AspNetCore.App && \
    rm -rf /var/lib/apt/lists/*

# Build c++ bridge
COPY clrhost/ /dotnet/clrhost
WORKDIR /dotnet/clrhost/build
RUN cmake -DCMAKE_BUILD_TYPE=Release .. && \
    make install

# Build .net bridge
COPY src /dotnet/src
RUN dotnet publish -c Linux -p:Version=$bridge_version -p:FileVersion=$bridge_version /dotnet/src/AlternateLife.RageMP.Net/AlternateLife.RageMP.Net.csproj && \ 
    cp /dotnet/src/AlternateLife.RageMP.Net/bin/Linux/netcoreapp2.2/publish/NLog.dll /ragemp-srv/dotnet/plugins/ && \
    cp /dotnet/src/AlternateLife.RageMP.Net/bin/Linux/netcoreapp2.2/publish/Newtonsoft.Json.dll /ragemp-srv/dotnet/plugins/ && \
    cp /dotnet/src/AlternateLife.RageMP.Net/bin/Linux/netcoreapp2.2/publish/NLog.config /ragemp-srv/dotnet/ && \
    rm -r /dotnet && \
    rm -r /usr/share/dotnet/sdk/NuGetFallbackFolder && \
    apt-get remove -y build-essential cmake wget libunwind8 apt-transport-https software-properties-common dotnet-sdk-2.2 && \
    apt-get autoremove -y

WORKDIR /ragemp-srv

EXPOSE 22005/udp
EXPOSE 22006/tcp

CMD cp -r /ragemp-config . && ./server
