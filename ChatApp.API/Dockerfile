#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChatApp.API/ChatApp.API.csproj", "ChatApp.API/"]
RUN dotnet restore "./ChatApp.API/./ChatApp.API.csproj"
COPY . .
WORKDIR "/src/ChatApp.API"
RUN dotnet build "./ChatApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChatApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQL="Server=chatsqlcontainer,1433;Database=ChatAppTestDb;User Id=SA;Password=Secret123;TrustServerCertificate=True"
ENTRYPOINT ["dotnet", "ChatApp.API.dll"]