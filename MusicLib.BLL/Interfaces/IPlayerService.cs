using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface IPlayerService 
    {
        Task CreatePlayer(PlayerDTO genreDto);
        Task UpdatePlayer(PlayerDTO genreDto);
        Task DeletePlayer(int id);
        Task<PlayerDTO> GetPlayer(int id);
        Task<IEnumerable<PlayerDTO>> GetPlayers();
    }
}

