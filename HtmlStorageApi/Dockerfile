# Use the official .NET 8 runtime image as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the official .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HtmlStorageApi.csproj", "./"]
RUN dotnet restore "HtmlStorageApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "HtmlStorageApi.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "HtmlStorageApi.csproj" -c Release -o /app/publish

# Use the base image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HtmlStorageApi.dll"]
