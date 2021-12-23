using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
     public class ConfigureMyContext
    {

        public static void ConfigureDependenciesMycontext(IServiceCollection serviceColletion)
        {

            serviceColletion.AddDbContext<MyContext>(
               options => options.UseSqlServer("Data Source=localhost;Initial Catalog=dbAPI;Persist Security Info=True;User ID=sa;Password=Feed@123;Connect Timeout=180;Encrypt=False;Current Language=Brazilian")
               );

        }
    
    }
}
