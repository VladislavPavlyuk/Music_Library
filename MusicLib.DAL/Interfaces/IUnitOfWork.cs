using MusicLib.DAL.Entities;

namespace MusicLib.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Genre> Genres { get; }
        IRepository<Song> Songs { get; }
        IRepository<Artist> Artists { get; }
        IRepository<Video> Videos { get; }
        Task Save();
    }
}
