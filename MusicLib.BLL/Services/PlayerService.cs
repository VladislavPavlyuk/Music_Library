using MusicLib.BLL.DTO;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.BLL.Infrastructure;
using MusicLib.BLL.Interfaces;
using AutoMapper;

namespace MusicLib.BLL.Services
{
    public class PlayerService : IPlayerService
    {
        IUnitOfWork Database { get; set; }

        public PlayerService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreatePlayer(PlayerDTO playerDto)
        {
            var player = new Player
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Age = playerDto.Age,
                Position = playerDto.Position,
                TeamId = playerDto.TeamId
            };
            await Database.Players.Create(player);
            await Database.Save();
        }

        public async Task UpdatePlayer(PlayerDTO playerDto)
        {
            var player = new Player
            {
                Id = playerDto.Id,
                Name = playerDto.Name,
                Age = playerDto.Age,
                Position = playerDto.Position,
                TeamId = playerDto.TeamId
            };
            Database.Players.Update(player);
            await Database.Save();
        }

        public async Task DeletePlayer(int id)
        {
            await Database.Players.Delete(id);
            await Database.Save();
        }

        public async Task<PlayerDTO> GetPlayer(int id)
        {
            var player = await Database.Players.Get(id);
            if (player == null)
                throw new ValidationException("Wrong player!", "");
            return new PlayerDTO
            {
                Id = player.Id,
                Name = player.Name,
                Age = player.Age,
                Position = player.Position,
                TeamId = player.TeamId,
                Team = player.Team?.Name
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.

        public async Task<IEnumerable<PlayerDTO>> GetPlayers()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Player, PlayerDTO>()
            .ForMember("Team", opt => opt.MapFrom(c => c.Team.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Player>, IEnumerable<PlayerDTO>>(await Database.Players.GetAll());
        }

    }
}
