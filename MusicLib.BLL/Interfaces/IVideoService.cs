using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface IVideoService
    {
        Task CreateVideo(VideoDTO videoDto);
        Task UpdateVideo(VideoDTO videoDto);
        Task DeleteVideo(int id);
        Task<VideoDTO> GetVideo(int id);
        Task<IEnumerable<VideoDTO>> GetVideos();
    }
}
