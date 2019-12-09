using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace AwesomeMusicManager.SongDownloader.Service
{
    public class DownloadService
    {

        public async Task DownloadVideoFromYoutube(string youtubeId)
        {
            var client = new YoutubeClient();

            // var videos = await client.SearchVideosAsync(youtubeId, 1);

// Get metadata for all streams in this video
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(youtubeId);

// Select one of the streams, e.g. highest quality muxed stream
            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();

// ...or highest bitrate audio stream
// var streamInfo = streamInfoSet.Audio.WithHighestBitrate();

// ...or highest quality & highest framerate MP4 video stream
// var streamInfo = streamInfoSet.Video
//    .Where(s => s.Container == Container.Mp4)
//    .OrderByDescending(s => s.VideoQuality)
//    .ThenByDescending(s => s.Framerate)
//    .First();

// Get file extension based on stream's container
            var ext = streamInfo.Container.GetFileExtension();

// Download stream to file
            await client.DownloadMediaStreamAsync(streamInfo, $"downloaded_video.{ext}");
        }
    }
}