using Microsoft.EntityFrameworkCore;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.EF;


namespace MusicLib.DAL.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private MusicLibContext db;

        public PlayerRepository(MusicLibContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await db.Players.Include(o => o.Genre).ToListAsync();
        }

        public async Task<Player> Get(int id)
        {
            var players = await db.Players.Include(o => o.Genre).Where(a => a.Id == id).ToListAsync();
            Player? player = players?.FirstOrDefault();
            return player!;
        }

        public async Task<Player> Get(string name)
        {         
            var players = await db.Players.Include(o => o.Genre).Where(a => a.Name == name).ToListAsync();
            Player? player = players?.FirstOrDefault();
            return player!;
        }

        public async Task Create(Player player)
        {
            await db.Players.AddAsync(player);
        }

        public void Update(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Player? player = await db.Players.FindAsync(id);
            if (player != null)
                db.Players.Remove(player);
        }

    }
}
