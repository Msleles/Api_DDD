using Domain.Services.user;
using Microsoft.Extensions.DependencyInjection;
using Services.Service;

namespace CrossCutting.DependencyInjection
{
   public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IUserService, UserService>();      
        }
    }
}
