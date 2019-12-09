FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AwesomeMusicManager.SongDownloader/AwesomeMusicManager.SongDownloader.WebApi/AwesomeMusicManager.SongDownloader.WebApi.csproj", "AwesomeMusicManager.SongDownloader/AwesomeMusicManager.SongDownloader.WebApi/"]
RUN dotnet restore "AwesomeMusicManager.SongDownloader/AwesomeMusicManager.SongDownloader.WebApi/AwesomeMusicManager.SongDownloader.WebApi.csproj"
COPY . .
WORKDIR "/src/AwesomeMusicManager.SongDownloader/AwesomeMusicManager.SongDownloader.WebApi"
RUN dotnet build "AwesomeMusicManager.SongDownloader.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AwesomeMusicManager.SongDownloader.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "AwesomeMusicManager.SongDownloader.WebApi.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AwesomeMusicManager.SongDownloader.WebApi.dll