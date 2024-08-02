using MusicLib.DAL.Entities;

namespace MusicLib.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Role> Roles { get; }
        IRepository<User> Users { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Song> Songs { get; }
        IRepository<Artist> Artists { get; }
        IRepository<Video> Videos { get; }
        Task Save();
    }
}
