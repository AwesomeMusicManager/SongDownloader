using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeMusicManager.SongDownloader.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoutubeExplode.Models.MediaStreams;

namespace AwesomeMusicManager.SongDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AudioStreamController : ControllerBase
    {
        private DownloadService _downloadService;

        public AudioStreamController()
        {
            _downloadService = new DownloadService();
        }

        [HttpGet]
        [Route("information/{youtubeId}")]
        public async Task<AudioStreamInfo> Get([FromRoute] string youtubeId)
        {
            return await _downloadService.DownloadVideoFromYoutube(youtubeId);
        }
    }
}