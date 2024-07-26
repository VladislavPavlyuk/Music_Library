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
        private GenreRepository genreRepository;
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
        public IRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
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