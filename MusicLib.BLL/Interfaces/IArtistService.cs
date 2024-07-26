using MusicLib.BLL.DTO;

namespace MusicLib.BLL.Interfaces
{
    public interface IArtistService
    {
        Task CreateArtist(ArtistDTO artistDto);
        Task UpdateArtist(ArtistDTO artistDto);
        Task DeleteArtist(int id);
        Task<ArtistDTO> GetArtist(int id);
        Task<IEnumerable<ArtistDTO>> GetArtists();
    }
}
