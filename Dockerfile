# STAGE 1 ->> Build Stage
FROM ubuntu:22.04 AS build

RUN apt-get update && \
    apt-get install -y wget xz-utils

RUN apt-get update && \
    apt-get install -y dotnet-sdk-8.0 

RUN wget https://nodejs.org/dist/v20.19.3/node-v20.19.3-linux-x64.tar.xz && \
    tar -xf node-v20.19.3-linux-x64.tar.xz && \
    mv node-v20.19.3-linux-x64 /usr/local/node && \
    ln -s /usr/local/node/bin/node /usr/local/bin/node && \
    ln -s /usr/local/node/bin/npm /usr/local/bin/npm && \
    ln -s /usr/local/node/bin/npx /usr/local/bin/npx && \
    rm node-v20.19.3-linux-x64.tar.xz

WORKDIR /app

COPY . /app

WORKDIR /app/yet-enibla.Web

RUN dotnet build "/app/yet-enibla.Web/yet-enibla.Web.csproj" -c Release -o /publish

RUN dotnet publish "/app/yet-enibla.Web/yet-enibla.Web.csproj" -c Release -o /publish /p:UseAppHost=false

# STAGE 2 ->> Run Time Stage
FROM ubuntu:22.04

RUN apt-get update && \
    apt-get install -y dotnet-sdk-8.0 && \
    apt-get install -y aspnetcore-runtime-8.0 && \
    apt-get install -y wget xz-utils

RUN wget https://nodejs.org/dist/v20.19.3/node-v20.19.3-linux-x64.tar.xz && \
    tar -xf node-v20.19.3-linux-x64.tar.xz && \
    mv node-v20.19.3-linux-x64 /usr/local/node && \
    ln -s /usr/local/node/bin/node /usr/local/bin/node && \
    ln -s /usr/local/node/bin/npm /usr/local/bin/npm && \
    ln -s /usr/local/node/bin/npx /usr/local/bin/npx && \
    rm node-v20.19.3-linux-x64.tar.xz

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /publish
COPY --from=build /publish .

WORKDIR /app
COPY --from=build /app .

WORKDIR /publish

EXPOSE 3000

ENTRYPOINT ["dotnet", "/publish/yet-enibla.Web.dll"]
