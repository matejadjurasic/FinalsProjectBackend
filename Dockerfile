# Development stage - live reload with dotnet watch
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS development
WORKDIR /src

# Install curl for healthcheck
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Copy csproj files and restore
COPY ["FitnessPal.API/FitnessPal.API.csproj", "FitnessPal.API/"]
COPY ["FitnessPal.Application/FitnessPal.Application.csproj", "FitnessPal.Application/"]
COPY ["FitnessPal.Domain/FitnessPal.Domain.csproj", "FitnessPal.Domain/"]
COPY ["FitnessPal.Infrastructure/FitnessPal.Infrastructure.csproj", "FitnessPal.Infrastructure/"]
COPY ["FitnessPal.Persistence/FitnessPal.Persistence.csproj", "FitnessPal.Persistence/"]

RUN dotnet restore "FitnessPal.API/FitnessPal.API.csproj"

# Copy everything (will be overridden by bind mount in development)
COPY . .

WORKDIR "/src/FitnessPal.API"

EXPOSE 80

CMD ["dotnet", "watch", "run", "--no-launch-profile"]

# ============================================
# Production Build Stages
# ============================================

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["FitnessPal.API/FitnessPal.API.csproj", "FitnessPal.API/"]
COPY ["FitnessPal.Application/FitnessPal.Application.csproj", "FitnessPal.Application/"]
COPY ["FitnessPal.Domain/FitnessPal.Domain.csproj", "FitnessPal.Domain/"]
COPY ["FitnessPal.Infrastructure/FitnessPal.Infrastructure.csproj", "FitnessPal.Infrastructure/"]
COPY ["FitnessPal.Persistence/FitnessPal.Persistence.csproj", "FitnessPal.Persistence/"]

RUN dotnet restore "FitnessPal.API/FitnessPal.API.csproj"

COPY . .
WORKDIR "/src/FitnessPal.API"
RUN dotnet build "FitnessPal.API.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "FitnessPal.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage (default)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FitnessPal.API.dll"]
