using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{

    // Interface onde (Entidade) é qualquer entidade herdada da classe base (Base Entity)

     public interface IRepository<Entidade> where Entidade:BaseEntity
    {
        //Métodos crud

        Task<Entidade> InsertAsync(Entidade Item);
        Task<Entidade> UpdateAsync(Entidade Item);
        Task<bool> DeleteAsync(Guid id);
        Task<Entidade> SelectAsync(Guid id);
        Task<IEnumerable<Entidade>> SelectAsync();
        Task<bool> ExistAsync(Guid Id);
    }


}
