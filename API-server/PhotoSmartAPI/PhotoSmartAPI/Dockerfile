# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files
COPY ["PhotoSmartAPI/PhotoSmartAPI.csproj", "PhotoSmartAPI/"]
COPY ["PhotoSmart.Core/PhotoSmart.Core.csproj", "PhotoSmart.Core/"]
COPY ["PhotoSmart.Data/PhotoSmart.Data.csproj", "PhotoSmart.Data/"]
COPY ["PhotoSmart.Service/PhotoSmart.Service.csproj", "PhotoSmart.Service/"]

# Restore dependencies
RUN dotnet restore "./PhotoSmartAPI/PhotoSmartAPI.csproj"

# Copy the entire source code
COPY . .

# Build the project
WORKDIR "/src/PhotoSmartAPI"
RUN dotnet build "./PhotoSmartAPI.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "./PhotoSmartAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoSmartAPI.dll"]
