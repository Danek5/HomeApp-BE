FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Home_app.csproj", "./"]
RUN dotnet restore "Home_app.csproj"

COPY . .

RUN dotnet build "Home_app.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Home_app.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 8080

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Home_app.dll"]
