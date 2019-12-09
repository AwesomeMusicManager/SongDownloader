FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY AwesomeMusicManager.SongDownloader/AwesomeMusicManager.SongDownloader.WebApi/bin/Release/netcoreapp3.1/publish/ app/
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "app/AwesomeMusicManager.SongDownloader.WebApi.dll"]