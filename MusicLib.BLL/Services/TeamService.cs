using MusicLib.BLL.DTO;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.BLL.Infrastructure;
using MusicLib.BLL.Interfaces;
using AutoMapper;

namespace MusicLib.BLL.Services
{
    public class TeamService: ITeamService
    {
        IUnitOfWork Database { get; set; }

        public TeamService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task CreateTeam(TeamDTO teamDto)
        {
            var team = new Team
            {
                Id = teamDto.Id,
                Name = teamDto.Name,
                Coach = teamDto.Coach
            };
            await Database.Teams.Create(team);
            await Database.Save();
        }

        public async Task UpdateTeam(TeamDTO teamDto)
        {
            var team = new Team
            {
                Id = teamDto.Id,
                Name = teamDto.Name,
                Coach = teamDto.Coach
            };
            Database.Teams.Update(team);
            await Database.Save();
        }

        public async Task DeleteTeam(int id)
        {
            await Database.Teams.Delete(id);
            await Database.Save();
        }

        public async Task<TeamDTO> GetTeam(int id)
        {
            var team = await Database.Teams.Get(id);
            if (team == null)
                throw new ValidationException("Wrong team!", "");
            return new TeamDTO
            {
                Id = team.Id,
                Name = team.Name,
                Coach = team.Coach
            };
        }

        // Automapper позволяет проецировать одну модель на другую, что позволяет сократить объемы кода и упростить программу.
        public async Task<IEnumerable<TeamDTO>> GetTeams()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Team, TeamDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Team>, IEnumerable<TeamDTO>>(await Database.Teams.GetAll());
        }

    }
}
