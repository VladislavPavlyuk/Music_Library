using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MusicLib.DAL.Entities;
using System.Diagnostics;

namespace MusicLib.DAL.EF
{   
    public class MusicLibContext : DbContext
    { 

        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasOne<Genre>(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Song>()
                .HasOne<Artist>(s => s.Artist)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Song>()
                .HasOne<Video>(s => s.Video)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.VideoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Video> Videos { get; set; }
        public MusicLibContext(DbContextOptions<MusicLibContext> options)
                   : base(options)
        {
            //Database.EnsureCreated();
            if (Database.EnsureCreated())
            {
                Roles.Add(new Role { Name = "Admin" });
                Roles.Add(new Role { Name = "User" });
                Roles.Add(new Role { Name = "Candidate" });

                Users.Add(new User { Email = "admin@admin.com", 
                    Password = "63F66566834843057ECD47890F10987FBD0D2022BB2A8ED84ED04890B9644E1C", 
                    Salt = "073B6AA3BED5420579D70404FD470461",
                    RoleId = 1 });

                SaveChanges();
            }
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
