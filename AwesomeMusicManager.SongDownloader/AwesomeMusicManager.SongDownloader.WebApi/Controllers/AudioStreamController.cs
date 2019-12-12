using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeMusicManager.SongDownloader.Model;
using AwesomeMusicManager.SongDownloader.Model.Interfaces;
using AwesomeMusicManager.SongDownloader.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YoutubeExplode.Models.MediaStreams;

namespace AwesomeMusicManager.SongDownloader.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AudioStreamController : ControllerBase
    {
        private IDownloadService _downloadService;
        private readonly ILogger<AudioStreamController> _logger;

        public AudioStreamController(ILogger<AudioStreamController> logger, IDownloadService service, IOptions<AlbumServiceOptions> albumService)
        {
            _logger = logger;
            _downloadService = service;
        }

        [HttpGet]
        [Route("information/{youtubeId}")]
        public async Task<AudioStreamInfo> Get([FromRoute] string youtubeId)
        {
            _logger.LogInformation("Iniciado fluxo de obtençao de stream de audio");
            return await _downloadService.DownloadVideoFromYoutube(youtubeId);
        }
        
        [HttpGet]
        [Route("information/album/{albumId}")]
        public async Task<Album> GetAlbumInformation([FromRoute] string albumId)
        {
            _logger.LogInformation("Iniciado fluxo de obtençao de dados de album");
            return await _downloadService.GetAlbumInfo(albumId);
        }
    }
}