
using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            
        }

    }
}
