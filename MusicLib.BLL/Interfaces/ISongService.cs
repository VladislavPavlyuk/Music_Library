using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface ISongService 
    {
        Task CreateSong(SongDTO songDto);
        Task UpdateSong(SongDTO songDto);
        Task DeleteSong(int id);
        Task<SongDTO> GetSong(int id);
        Task<IEnumerable<SongDTO>> GetSongs();
    }
}

