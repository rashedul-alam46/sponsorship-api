# =========================
# BUILD STAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy solution file
COPY Sponsorship.sln .

# Copy project files
COPY Sponsorship.Api/*.csproj Sponsorship.Api/
COPY Sponsorship.Application/*.csproj Sponsorship.Application/
COPY Sponsorship.Domain/*.csproj Sponsorship.Domain/
COPY Sponsorship.Infrastructure/*.csproj Sponsorship.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Copy all source code
COPY . .

# Publish API project
WORKDIR /src/Sponsorship.Api

RUN dotnet publish -c Release -o /app/publish

# =========================
# RUNTIME STAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Sponsorship.Api.dll"]