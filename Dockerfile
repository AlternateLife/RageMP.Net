FROM ubuntu

ARG bridge_version=1.0.0.0

# Install tools
RUN apt-get update && apt-get install -y build-essential cmake wget libunwind8 apt-transport-https gdb software-properties-common

# Install .Net core sdk
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN add-apt-repository universe
RUN apt-get update && apt-get install -y dotnet-sdk-2.2
RUN rm packages-microsoft-prod.deb

# Install ragemp server
RUN wget https://cdn.rage.mp/lin/ragemp-srv-037.tar.gz
RUN tar -xzvf ragemp-srv-037.tar.gz
RUN rm ragemp-srv-037.tar.gz

# Install .Net core clr runtime
WORKDIR /ragemp-srv
RUN mkdir -p dotnet/plugins
RUN mkdir -p dotnet/resources
RUN mkdir -p dotnet/runtime/download
WORKDIR /ragemp-srv/dotnet/runtime/download
RUN wget https://download.visualstudio.microsoft.com/download/pr/372f18c3-f642-4b73-8255-40a87430a9bb/dd0b412220dc49868b0ba1c58252b6d0/dotnet-runtime-2.2.1-linux-x64.tar.gz
RUN tar -zxvf dotnet-runtime-2.2.1-linux-x64.tar.gz
RUN cp shared/Microsoft.NETCore.App/2.2.1/* ../
WORKDIR /ragemp-srv/dotnet/runtime
RUN rm -r download

# Build c++ bridge
RUN mkdir -p /dotnet/clrhost/build
WORKDIR /dotnet/clrhost/build
COPY clrhost/ ..

RUN cmake -DCMAKE_BUILD_TYPE=Release ..
RUN make install

# Build .net bridge
RUN mkdir /dotnet/src
WORKDIR /dotnet/src
COPY src .
WORKDIR /dotnet/src/AlternateLife.RageMP.Net
RUN dotnet publish -c Linux -p:Version=$bridge_version -p:FileVersion=$bridge_version

RUN cp bin/Linux/netcoreapp2.2/publish/NLog.dll /ragemp-srv/dotnet/plugins/
RUN cp bin/Linux/netcoreapp2.2/publish/Newtonsoft.Json.dll /ragemp-srv/dotnet/plugins/
RUN cp bin/Linux/netcoreapp2.2/publish/NLog.config /ragemp-srv/dotnet/

WORKDIR /ragemp-srv
RUN mkdir /ragemp-config

EXPOSE 22005/udp
EXPOSE 22006/tcp

CMD cp -r /ragemp-config . && ./server
