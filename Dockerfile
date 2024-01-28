FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Install web server
RUN apt-get update && apt-get install -y npm
RUN npm install -g serve

USER app
WORKDIR /app
## Expose API
EXPOSE 8080
## Expose UI
EXPOSE 4200

# Build API
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Calculus.Api/Calculus.Api/Calculus.Api.csproj", "Calculus.Api/"]
RUN dotnet restore "./Calculus.Api/./Calculus.Api.csproj"
COPY ./Calculus.Api/ .
WORKDIR "/src/Calculus.Api"
RUN dotnet build "./Calculus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Calculus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Build UI
## Setting up Volta for managing Node and NPM
ENV BASH_ENV ~/.bashrc
ENV VOLTA_HOME /root/.volta
ENV PATH $VOLTA_HOME/bin:$PATH
RUN curl https://get.volta.sh | bash

## Build the frontend app
WORKDIR /src/ui
COPY calculus-ui/package.json calculus-ui/package-lock.json ./
RUN npm ci
COPY ./calculus-ui .
RUN npm run build

# Build final image
FROM base AS final
# Copy UI artifacts
WORKDIR /app/ui
COPY --from=publish /src/ui/dist/calculus-ui/browser .

## Copy API artifacts
WORKDIR /app
COPY --from=publish /app/publish .

## Copy main script and web server config
COPY ./run.sh .
COPY ./serve.json ./ui
ENTRYPOINT ["./run.sh"]
