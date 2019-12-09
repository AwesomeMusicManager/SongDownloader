using System;
using Microsoft.AspNetCore.Hosting;

namespace AwesomeMusicManager.SongDownloader.WebApi
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UsePort(this IWebHostBuilder builder)
        {
            var port = Environment.GetEnvironmentVariable("PORT");
            return string.IsNullOrEmpty(port) ? builder : builder.UseUrls($"http://+:{port}");
        }
    }
}