using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AwesomeMusicManager.SongDownloader.Model;
using AwesomeMusicManager.SongDownloader.Model.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using Newtonsoft.Json;
using YoutubeExplode.Models;
using System.Collections.Generic;
using System.Linq;

namespace AwesomeMusicManager.SongDownloader.Service
{
    public class DownloadService : IDownloadService
    {
        private readonly IOptions<AlbumServiceOptions> _albumService;

        private readonly ILogger<DownloadService> _logger;
        
        public DownloadService(IOptions<AlbumServiceOptions> albumService, ILogger<DownloadService> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }

        public async Task<AudioStreamInfo> DownloadVideoFromYoutube(string youtubeId)
        {
            var client = new YoutubeClient();

            // var videos = await client.SearchVideosAsync(youtubeId, 1);
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(youtubeId);
            var streamInfo = streamInfoSet.Audio.WithHighestBitrate();

            // Get file extension based on stream's container
            var ext = streamInfo.Container.GetFileExtension();
            
            //await client.DownloadMediaStreamAsync(streamInfo, $"downloaded_video.{ext}");
            return streamInfo;
        }
        
        public async Task<Album> GetAlbumInfo(string albumId)
        {
            var client = new HttpClient();

            // var videos = await client.SearchVideosAsync(youtubeId, 1);
            var albumResponse = client.GetAsync($"{_albumService.Value.Uri}api/album/{albumId}").Result;

            if (albumResponse.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Album>(albumResponse.Content.ReadAsStringAsync().Result);
            }
            
            _logger.LogError("O request nao foi bem sucedido", albumResponse);
            return null;
        }

        public async Task<Video> SearchYoutubeVideo(string query)
        {
            var client = new YoutubeClient();

            // var videos = await client.SearchVideosAsync(youtubeId, 1);
            //var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(youtubeId);
            //var streamInfo = streamInfoSet.Audio.WithHighestBitrate();
            var videos = await client.SearchVideosAsync(query, 1);

            // Get file extension based on stream's container
            //var ext = streamInfo.Container.GetFileExtension();

            //await client.DownloadMediaStreamAsync(streamInfo, $"downloaded_video.{ext}");
            return videos.First();
        }
    }
}