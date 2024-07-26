using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface IGenreService 
    {
        Task CreateGenre(GenreDTO genreDto);
        Task UpdateGenre(GenreDTO genreDto);
        Task DeleteGenre(int id);
        Task<GenreDTO> GetGenre(int id);
        Task<IEnumerable<GenreDTO>> GetGenres();
    }
}
