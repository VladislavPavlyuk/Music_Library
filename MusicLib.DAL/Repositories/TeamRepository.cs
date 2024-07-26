using Microsoft.EntityFrameworkCore;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.EF;

namespace MusicLib.DAL.Repositories
{
    public class TeamRepository : IRepository<Team>
    {
        private MusicLibContext db;

        public TeamRepository(MusicLibContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await db.Teams.ToListAsync();
        }

        public async Task<Team> Get(int id)
        {
            Team? team = await db.Teams.FindAsync(id);
            return team!;
        }

        public async Task<Team> Get(string name)
        {
            var teams = await db.Teams.Where(a => a.Name == name).ToListAsync(); 
            Team? team = teams?.FirstOrDefault();
            return team!;
        }

        public async Task Create(Team team)
        {
            await db.Teams.AddAsync(team);
        }

        public void Update(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Team? team = await db.Teams.FindAsync(id);
            if (team != null)
                db.Teams.Remove(team);
        }
    }
}
