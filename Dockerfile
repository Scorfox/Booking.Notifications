#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notification.API/Notification.API.csproj", "Notification.API/"]
RUN dotnet restore "./Notification.API/./Notification.API.csproj"
COPY . .
WORKDIR "/src/Notification.API"
RUN dotnet build "./Notification.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Notification.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.dll"]