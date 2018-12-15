FROM ubuntu

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
RUN wget https://download.visualstudio.microsoft.com/download/pr/1057e14e-16cc-410b-80a4-5c2420c8359c/004dc3ce8255475d4723de9a011ac513/dotnet-runtime-2.2.0-linux-x64.tar.gz
RUN tar -zxvf dotnet-runtime-2.2.0-linux-x64.tar.gz
RUN cp shared/Microsoft.NETCore.App/2.2.0/* ../
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
RUN dotnet publish -c Linux

RUN cp bin/Linux/netcoreapp2.2/publish/NLog.dll /ragemp-srv/dotnet/plugins/
RUN cp bin/Linux/netcoreapp2.2/publish/Newtonsoft.Json.dll /ragemp-srv/dotnet/plugins/
RUN cp bin/Linux/netcoreapp2.2/publish/NLog.config /ragemp-srv/dotnet/

WORKDIR /ragemp-srv
RUN mkdir /ragemp-config

EXPOSE 22005/udp
EXPOSE 22006/tcp

CMD cp -r /ragemp-config . && ./server
