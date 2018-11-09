FROM ubuntu

# Install tools
RUN apt-get update
RUN apt-get install -y build-essential cmake wget libunwind8 apt-transport-https gdb

# Install .Net core sdk
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get update
RUN apt-get install -y dotnet-sdk-2.1
RUN rm packages-microsoft-prod.deb

# Install ragemp server
RUN wget https://cdn.rage.mp/lin/ragemp-srv-036.tar.gz
RUN tar -xzvf ragemp-srv-036.tar.gz
RUN rm ragemp-srv-036.tar.gz

# Install .Net core clr runtime
WORKDIR /ragemp-srv
RUN mkdir -p dotnet/plugins
RUN mkdir -p dotnet/resources
RUN mkdir -p dotnet/runtime/download
WORKDIR /ragemp-srv/dotnet/runtime/download
RUN wget https://download.visualstudio.microsoft.com/download/pr/05a71d80-3e59-4f1f-8298-2697013e261c/be191f2f4f4db74c29030008ed3632f0/dotnet-runtime-2.1.5-linux-x64.tar.gz
RUN tar -zxvf dotnet-runtime-2.1.5-linux-x64.tar.gz
RUN cp shared/Microsoft.NETCore.App/2.1.5/* ../
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

RUN cp bin/Linux/netcoreapp2.1/publish/NLog.dll /ragemp-srv/dotnet/plugins/
RUN cp bin/Linux/netcoreapp2.1/publish/Newtonsoft.Json.dll /ragemp-srv/dotnet/plugins/
RUN cp bin/Linux/netcoreapp2.1/publish/NLog.config /ragemp-srv/dotnet/

WORKDIR /ragemp-srv

EXPOSE 22005/udp
EXPOSE 22006/tcp

CMD ./server
