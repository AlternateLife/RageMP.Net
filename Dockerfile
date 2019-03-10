FROM ubuntu

ARG bridge_version=1.0.0.0

# Install tools
RUN apt-get update && \
    apt-get install -y build-essential cmake wget libunwind8 apt-transport-https gdb software-properties-common && \
    add-apt-repository universe

# Install .Net core sdk
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y dotnet-sdk-2.2

# Install ragemp server
RUN wget https://cdn.rage.mp/lin/ragemp-srv-037.tar.gz && \
    tar -xzvf ragemp-srv-037.tar.gz && \
    rm ragemp-srv-037.tar.gz

# Create directories
RUN mkdir -p /ragemp-srv/dotnet/plugins && \
    mkdir -p /ragemp-srv/dotnet/resources && \
    mkdir -p /ragemp-srv/dotnet/runtime/download && \
    mkdir /ragemp-config && \
    mkdir -p /dotnet/clrhost/build && \
    mkdir -p /dotnet/src

# Install .Net core clr runtime
WORKDIR /ragemp-srv/dotnet/runtime/download
RUN wget https://download.visualstudio.microsoft.com/download/pr/97b97652-4f74-4866-b708-2e9b41064459/7c722daf1a80a89aa8c3dec9103c24fc/dotnet-runtime-2.2.2-linux-x64.tar.gz && \
    tar -zxvf dotnet-runtime-2.2.2-linux-x64.tar.gz
WORKDIR /ragemp-srv/dotnet/runtime
RUN rm -r download

# Build c++ bridge
COPY clrhost/ /dotnet/clrhost
WORKDIR /dotnet/clrhost/build
RUN cmake -DCMAKE_BUILD_TYPE=Release .. && \
    make install

# Build .net bridge
COPY src /dotnet/src
WORKDIR /dotnet/src/AlternateLife.RageMP.Net
RUN dotnet publish -c Linux -p:Version=$bridge_version -p:FileVersion=$bridge_version

RUN cp bin/Linux/netcoreapp2.2/publish/NLog.dll /ragemp-srv/dotnet/plugins/ && \
    cp bin/Linux/netcoreapp2.2/publish/Newtonsoft.Json.dll /ragemp-srv/dotnet/plugins/ && \
    cp bin/Linux/netcoreapp2.2/publish/NLog.config /ragemp-srv/dotnet/

WORKDIR /ragemp-srv

EXPOSE 22005/udp
EXPOSE 22006/tcp

CMD cp -r /ragemp-config . && ./server
