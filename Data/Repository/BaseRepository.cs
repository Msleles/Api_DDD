using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    //clase base que recebe uma Entidade e é herdada da Interface IRepository que implementa o crud padrao 
    //quando a Entidade passada na classe é Herdada da entidade BaseEntity

    public class BaseRepository<Entidade> : IRepository<Entidade> where Entidade : BaseEntity
    {


        protected readonly MyContext _context;
        private DbSet<Entidade> _dataSet;

        //Construtor
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<Entidade>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {

            try
            {
                var result = await _dataSet
                    .SingleOrDefaultAsync(e => e.Id.Equals(id));

                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<Entidade> InsertAsync(Entidade Item)
        {
            try

            {
                if (Item.Id == Guid.Empty)
                {
                    Item.Id = Guid.NewGuid();
                }

                Item.CreateAt = DateTime.UtcNow;
                _dataSet.Add(Item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Item;

            }

        public async Task<Entidade> SelectAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
                if(result ==null)
                    return null;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Entidade>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Entidade> UpdateAsync(Entidade Item)
        {

            try
            {
                var result = await _dataSet
                    .SingleOrDefaultAsync(e => e.Id.Equals(Item.Id));
                if (result == null)
                    return null;

                Item.UpdateAt = DateTime.UtcNow;
                Item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(Item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return Item;

        }

        public async Task<bool> ExistAsync(Guid Id)
        {
            return await _dataSet.AnyAsync(e => e.Id.Equals(Id));
        }

    } 

  }

