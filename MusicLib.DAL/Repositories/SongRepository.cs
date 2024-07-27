using Microsoft.EntityFrameworkCore;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.EF;


namespace MusicLib.DAL.Repositories
{
    public class SongRepository : IRepository<Song>
    {
        private MusicLibContext db;

        public SongRepository(MusicLibContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            return await db.Songs.Include(o => o.Genre).
                                    Include(o => o.Artist).
                                    Include(o => o.Video).ToListAsync();
        }

        public async Task<Song> Get(int id)
        {
            var songs = await db.Songs.Include(o => o.Genre).Where(a => a.Id == id)
                .Include(o => o.Artist).Where(a => a.Id == id)
                .Include(o => o.Video).Where(a => a.Id == id)
                .ToListAsync();
            Song? song = songs?.FirstOrDefault();
            return song!;
        }

        public async Task<Song> Get(string name)
        {         
            var songs = await db.Songs.Include(o => o.Genre).Where(a => a.Name == name)
                .Include(o => o.Artist).Where(a => a.Name == name)
                .Include(o => o.Video).Where(a => a.Name == name)
                .ToListAsync();

            Song? song = songs?.FirstOrDefault();
            return song!;
        }

        public async Task Create(Song song)
        {
            await db.Songs.AddAsync(song);
        }

        public void Update(Song song)
        {
            db.Entry(song).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
                Song? song = await db.Songs.FindAsync(id);
                if (song != null)
                    db.Songs.Remove(song);            
        }
    }
}
