# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy everything and restore dependencies
COPY . .
RUN dotnet restore

# Build and publish in Release mode
RUN dotnet publish -c Release -o /app/publish --no-restore

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Set environment to Development
ENV ASPNETCORE_ENVIRONMENT=Development

# Expose default HTTP port
EXPOSE 8080

# Run the app (replace DLL name if different)
ENTRYPOINT ["dotnet", "BackendForBeginners-Net10-Solution.dll"]
