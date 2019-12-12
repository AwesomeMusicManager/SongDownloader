using System.Threading.Tasks;
using YoutubeExplode.Models.MediaStreams;

namespace AwesomeMusicManager.SongDownloader.Model.Interfaces
{
    public interface IDownloadService
    {
        Task<AudioStreamInfo> DownloadVideoFromYoutube(string youtubeId);

        Task<Album> GetAlbumInfo(string albumId);
    }
}