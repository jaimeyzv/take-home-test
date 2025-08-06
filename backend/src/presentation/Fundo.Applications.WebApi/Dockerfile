# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy everything from the backend/src folder
COPY ../../../backend/src/ ./

# Restore and build the solution
RUN dotnet restore "src.sln"
RUN dotnet build "src.sln" -c Release --no-restore

# Publish the WebApi project only
RUN dotnet publish "Presentation/Fundo.Applications.WebApi/Fundo.Applications.WebApi.csproj" -c Release -o /app/publish --no-build


# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Fundo.Applications.WebApi.dll"]