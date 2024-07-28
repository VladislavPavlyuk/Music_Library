using MusicLib.BLL.DTO;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.BLL.Infrastructure;
using MusicLib.BLL.Interfaces;
using AutoMapper;

namespace MusicLib.BLL.Services
{
    public class GenreService: IGenreService
    {
        IUnitOfWork Database { get; set; }

        public GenreService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreateGenre(GenreDTO genreDto)
        {
            var genre = new Genre
            {
                Id = genreDto.Id,
                Name = genreDto.Name
            };
            await Database.Genres.Create(genre);

            await Database.Save();
        }

        public async Task UpdateGenre(GenreDTO genreDto)
        {
            var genre = new Genre
            {
                Id = genreDto.Id,
                Name = genreDto.Name,
            };
            Database.Genres.Update(genre);

            await Database.Save();
        }

        public async Task DeleteGenre(int id)
        {
            await Database.Genres.Delete(id);
            await Database.Save();
            /*
            try {            
                await Database.Genres.Delete(id);
                await Database.Save();
            } catch (Exception ex)
            { }*/
        }
        public async Task<GenreDTO> GetGenre(int id)
        {
            var genre = await Database.Genres.Get(id);

            if (genre == null)
                throw new ValidationException("Wrong genre!", "");

            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.
        public async Task<IEnumerable<GenreDTO>> GetGenres()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Genre, GenreDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(await Database.Genres.GetAll());
        }

    }
}
