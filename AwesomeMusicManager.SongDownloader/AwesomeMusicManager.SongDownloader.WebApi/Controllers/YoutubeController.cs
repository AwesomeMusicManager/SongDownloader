using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeMusicManager.SongDownloader.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomeMusicManager.SongDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private DownloadService _downloadService;

        public YoutubeController()
        {
            _downloadService = new DownloadService();
        }

        [HttpGet]
        [Route("/download-audio/{youtubeQuery}")]
        public async Task Get([FromRoute] string youtubeQuery)
        {
            await _downloadService.DownloadVideoFromYoutube(youtubeQuery);

        }
    }
}