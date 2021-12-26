using Domain.Entities;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Domain.Services.User
{
  
        public interface ITypePeopleService
        {
            Task<TypePeople> Get(Guid id);
            Task<IEnumerable<TypePeople>> GetAll();
            Task<TypePeople> Post(TypePeople type);
            Task<TypePeople> Put(TypePeople type);
            Task<bool> Delete(Guid id);
        }
    
}
