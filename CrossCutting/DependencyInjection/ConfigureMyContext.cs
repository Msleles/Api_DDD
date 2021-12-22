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
               options => options.UseSqlServer("Data Source=192.168.0.110;Initial Catalog=dbAPI;Persist Security Info=True;User ID=sa;Password=feed333;Connect Timeout=180;Encrypt=False;Current Language=Brazilian")
               );

        }
    
    }
}
