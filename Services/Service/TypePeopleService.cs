using Domain.Entities;
using Domain.Interfaces;
using Domain.Services.User;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Services.Service
{
    public class TypePeopleService : ITypePeopleService

    {
        private IRepository<TypePeople> _repository;


        public TypePeopleService(IRepository<TypePeople> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<TypePeople> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<TypePeople>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<TypePeople> Post(TypePeople type)
        {
            return await _repository.InsertAsync(type);
        }

        public async Task<TypePeople> Put(TypePeople type)
        {
            return await _repository.UpdateAsync(type);
        }
    }
}
