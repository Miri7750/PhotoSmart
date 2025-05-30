# Use the ASP.NET runtime image as the base for the final image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files to the container
COPY ["PhotoSmartAPI/PhotoSmart.API.csproj", "PhotoSmartAPI/"]
COPY ["PhotoSmart.Data/PhotoSmart.Data.csproj", "PhotoSmart.Data/"]
COPY ["PhotoSmart.Core/PhotoSmart.Core.csproj", "PhotoSmart.Core/"]
COPY ["PhotoSmart.Service/PhotoSmart.Service.csproj", "PhotoSmart.Service/"]

# Restore dependencies
RUN dotnet restore "PhotoSmartAPI/PhotoSmart.API.csproj"

# Copy the rest of the application code
COPY . .

# Build the application
WORKDIR "/src/PhotoSmartAPI"
RUN dotnet build "PhotoSmart.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PhotoSmart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage to create the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoSmart.API.dll"]
