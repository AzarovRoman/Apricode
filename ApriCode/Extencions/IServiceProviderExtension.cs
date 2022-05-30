using ApriCode.Bll.Services;
using ApriCode.Bll.Services.Interfaces;
using ApriCode.Dal.Repositories;
using ApriCode.Dal.Repositories.Interfaces;

namespace ApriCode.Extencions
{
    public static class IServiceProviderExtension
    {
        public static void RegisterProjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        public static void RegisterProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();
        }
    }
}
