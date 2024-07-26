using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface ISongService 
    {
        Task CreateSong(SongDTO genreDto);
        Task UpdateSong(SongDTO genreDto);
        Task DeleteSong(int id);
        Task<SongDTO> GetSong(int id);
        Task<IEnumerable<SongDTO>> GetSongs();
    }
}

