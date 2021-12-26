using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.User
{
   public interface IPeopleService
    {
        Task<People> Get(Guid id);
        Task<IEnumerable<People>> GetAll();
        Task<People> Post(People people);
        Task<People> Put(People people);
        Task<bool> Delete(Guid id);
    }
}
