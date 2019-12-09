using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace AwesomeMusicManager.SongDownloader.Service
{
    public class DownloadService
    {

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
    }
}