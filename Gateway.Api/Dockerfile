#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app

EXPOSE 80
EXPOSE 443

RUN apt-get update
RUN apt-get install -y curl

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Gateway.Api/Gateway.Api.csproj", "Gateway.Api/"]
RUN dotnet restore "./Gateway.Api/./Gateway.Api.csproj"
COPY . .
WORKDIR "/src/Gateway.Api"
RUN dotnet build "./Gateway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./Gateway.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.Api.dll"]