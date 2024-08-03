using Microsoft.EntityFrameworkCore;
using MusicLib.DAL.Entities;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.EF;

namespace MusicLib.DAL.Repositories
{
    public class VideoRepository : IRepository<Video>
    {
        private MusicLibContext db;
        public VideoRepository(MusicLibContext context)
        {
            this.db = context;
        }
        public async Task<IEnumerable<Video>> GetAll()
        {
            return await db.Videos.ToListAsync();
        }
        public async Task<Video> Get(int id)
        {
            Video? video = await db.Videos.FindAsync(id);
            return video!;
        }
        public async Task<Video> Get(string name)
        {
            var videos = await db.Videos.Where(a => a.FileName == name).ToListAsync();
            Video? video = videos?.FirstOrDefault();
            return video!;
        }
        public async Task Create(Video video)
        {
            await db.Videos.AddAsync(video);
        }
        public void Update(Video video)
        {
            db.Entry(video).State = EntityState.Modified;
        }
        public async Task Delete(int id)
        {
            Video? video = await db.Videos.FindAsync(id);
            if (video != null)
                db.Videos.Remove(video);
        }
    }
}
