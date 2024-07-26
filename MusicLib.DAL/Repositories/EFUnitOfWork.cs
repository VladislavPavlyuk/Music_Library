using MusicLib.DAL.EF;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.Entities;

namespace MusicLib.DAL.Repositories
{
    /*
     * Паттерн Unit of Work позволяет упростить работу с различными репозиториями и дает уверенность, 
     * что все репозитории будут использовать один и тот же контекст данных.
    */

    public class EFUnitOfWork : IUnitOfWork
    {
        private MusicLibContext db;
        private PlayerRepository playerRepository;
        private TeamRepository teamRepository;
        private ArtistRepository artistRepository;
        private VideoRepository videoRepository;

        public EFUnitOfWork(MusicLibContext context)
        {
            db = context;
        }
        public IRepository<Video> Videos
        {
            get
            {
                if (videoRepository == null)
                    videoRepository = new VideoRepository(db);
                return videoRepository;
            }
        }
        public IRepository<Artist> Artists
        {
            get
            {
                if (artistRepository == null)
                    artistRepository = new ArtistRepository(db);
                return artistRepository;
            }
        }
        public IRepository<Team> Teams
        {
            get
            {
                if (teamRepository == null)
                    teamRepository = new TeamRepository(db);
                return teamRepository;
            }
        }

        public IRepository<Player> Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(db);
                return playerRepository;
            }
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
       
    }
}