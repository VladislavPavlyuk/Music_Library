using Microsoft.Extensions.DependencyInjection;
using MusicLib.DAL.Interfaces;
using MusicLib.DAL.Repositories;

namespace MusicLib.BLL.Infrastructure
{
    public static class UnitOfWorkServiceExtensions
    {
        public static void AddUnitOfWorkService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
