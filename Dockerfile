# use the .net sdk image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# install required packages and node via nvm
RUN apt-get update && apt-get install -y curl bash && \
    curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.40.3/install.sh | bash && \
    export NVM_DIR="$HOME/.nvm" && \
    . "$NVM_DIR/nvm.sh" && \
    nvm install --lts=iron && \
    nvm use --lts=iron && \
    ln -s "$NVM_DIR/versions/node/$(ls $NVM_DIR/versions/node)/bin/node" /usr/bin/node && \
    ln -s "$NVM_DIR/versions/node/$(ls $NVM_DIR/versions/node)/bin/npm" /usr/bin/npm && \
    node -v && npm -v

# set the working directory inside the container
WORKDIR /src

# copy the entire solution to the container
COPY . ./

# install dependencies for project
WORKDIR /src/yet-enibla.Web
RUN npm install

# set the working directory inside the container
WORKDIR /src

# restore dependencies of the .sln file
RUN dotnet restore yet-enibla.sln

# build the application project within the solution in release mode
RUN dotnet publish yet-enibla.Web/yet-enibla.Web.csproj -c Release -o /app/publish

# use the .net runtime image for running the application
FROM mcr.microsoft.com/dotnet/runtime:9.0

# working directory for the run time container
WORKDIR /app

# copy the published application from the build stage
COPY  --from=build /app/publish .

# expose the default port the application will run on
EXPOSE 80
EXPOSE 443

# set the command to run the application
ENTRYPOINT ["dotnet", "yet-enibla.web.dll"]
