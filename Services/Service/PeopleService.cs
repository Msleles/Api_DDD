using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class PeopleService : IPeopleService
    {

        private readonly IRepository<People> _repository;

        public PeopleService(IRepository<People> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<People> Get(Guid id)
        {                      
           return await _repository.SelectAsync(id)  ;
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<People> Post(People people)
        {
            return await _repository.InsertAsync(people);
        }

        public async Task<People> Put(People people)
        {
            return await _repository.UpdateAsync(people);
        }
    }
}
