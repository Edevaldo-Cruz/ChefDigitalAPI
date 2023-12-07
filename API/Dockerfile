#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/ChefDigital.API.csproj", "API/"]
COPY ["ChefDigital.Domain.Service/ChefDigital.Domain.Service.csproj", "ChefDigital.Domain.Service/"]
COPY ["ChefDigital.Domain/ChefDigital.Domain.csproj", "ChefDigital.Domain/"]
COPY ["ChefDigital.Entities/ChefDigital.Entities.csproj", "ChefDigital.Entities/"]
COPY ["ChefDigital.Infra/ChefDigital.Infra.csproj", "ChefDigital.Infra/"]
COPY ["ChefDigitalAPI.Application/ChefDigitalAPI.Application.csproj", "ChefDigitalAPI.Application/"]
RUN dotnet restore "./API/./ChefDigital.API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "./ChefDigital.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ChefDigital.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChefDigital.API.dll"]