# Base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClimasService.Api/ClimasService.Api.csproj", "ClimasService.Api/"]
COPY ["ClimasService.Application/ClimasService.Application.csproj", "ClimasService.Application/"]
RUN dotnet restore "ClimasService.Api/ClimasService.Api.csproj"
COPY . .
WORKDIR "/src/ClimasService.Api"
RUN dotnet build "ClimasService.Api.csproj" -c Release -o /app/build

# Copy SSL certificate to the container
COPY ["myapp.pfx", "/app/myapp.pfx"]

# Set environment variables for ASP.NET Core to use the certificate
ENV ASPNETCORE_URLS=https://+:443;http://+:80
ENV ASPNETCORE_HTTPS_PORT=443
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/myapp.pfx

# Publish image
FROM build AS publish
RUN dotnet publish "ClimasService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClimasService.Api.dll"]
