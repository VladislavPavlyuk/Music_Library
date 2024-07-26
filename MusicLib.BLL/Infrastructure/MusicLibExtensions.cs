using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MusicLib.DAL.EF;


namespace MusicLib.BLL.Infrastructure
{
    public static class MusicLibExtensions
    {
        public static void AddMusicLibContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MusicLibContext>(options => options.UseSqlServer(connection));
        }
    }
}
