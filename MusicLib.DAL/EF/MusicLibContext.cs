using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MusicLib.DAL.Entities;

namespace MusicLib.DAL.EF
{   
    public class MusicLibContext : DbContext
    { 
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Video> Videos { get; set; }
        public MusicLibContext(DbContextOptions<MusicLibContext> options)
                   : base(options)
        {
            Database.EnsureCreated();
        }
    }
    // Класс необходим исключительно для миграций
    public class SampleContextFactory : IDesignTimeDbContextFactory<MusicLibContext>
    {
        public MusicLibContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicLibContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            // получаем строку подключения из файла appsettings.json
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new MusicLibContext(optionsBuilder.Options);
        }
    }
}
