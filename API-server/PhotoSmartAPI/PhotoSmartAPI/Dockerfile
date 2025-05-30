# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["PhotoSmartAPI/PhotoSmart.API.csproj", "PhotoSmartAPI/"]
COPY ["PhotoSmartAPI/PhotoSmart.Data/PhotoSmart.Data.csproj", "PhotoSmart.Data/"]
COPY ["PhotoSmartAPI/PhotoSmart.Core/PhotoSmart.Core.csproj", "PhotoSmart.Core/"]
COPY ["PhotoSmartAPI/PhotoSmart.Service/PhotoSmart.Service.csproj", "PhotoSmart.Service/"]
RUN dotnet restore "PhotoSmartAPI/PhotoSmart.API.csproj"
COPY . .
WORKDIR "/src/PhotoSmartAPI"
RUN dotnet build "PhotoSmart.API.csproj" -c Release -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
RUN dotnet publish "PhotoSmart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoSmart.API.dll"]
