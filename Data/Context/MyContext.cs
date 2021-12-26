using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
   public class MyContext : DbContext
    {

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TypePeople> TypePeoples { get; set; }

        public DbSet<People> Peoples { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity> (new UserMap().Configure);
            modelBuilder.Entity<TypePeople>(new TypePeoplesMap().Configure);
            modelBuilder.Entity<People>(new PeopleMap().Configure);
        }

       
    }
}
