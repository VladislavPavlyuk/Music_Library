using MusicLib.BLL.DTO;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.BLL.Infrastructure;
using MusicLib.BLL.Interfaces;
using AutoMapper;

namespace MusicLib.BLL.Services
{
    public class ArtistService : IArtistService
    {
        IUnitOfWork Database { get; set; }

        public ArtistService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreateArtist(ArtistDTO artistDto)
        {
            var artist = new Artist
            {
                Id = artistDto.Id,
                Name = artistDto.Name,
                Birthdate = artistDto.Birthdate

            };
            await Database.Artists.Create(artist);

            await Database.Save();
        }

        public async Task UpdateArtist(ArtistDTO artistDto)
        {
            var artist = new Artist
            {
                Id = artistDto.Id,
                Name = artistDto.Name,
                Birthdate = artistDto.Birthdate
            };
            Database.Artists.Update(artist);

            await Database.Save();
        }

        public async Task DeleteArtist(int id)
        {
            try 
            { 
                await Database.Artists.Delete(id);

                await Database.Save();            
            } 
            catch (Exception ex)
            {

            }
}

        public async Task<ArtistDTO> GetArtist(int id)
        {
            var artist = await Database.Artists.Get(id);

            if (artist == null)
                throw new ValidationException("Wrong artist!", "");

            return new ArtistDTO
            {
                Id = artist.Id,
                Name = artist.Name,
                Birthdate = artist.Birthdate
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.
        public async Task<IEnumerable<ArtistDTO>> GetArtists()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Artist, ArtistDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDTO>>(await Database.Artists.GetAll());
        }
    }
}
