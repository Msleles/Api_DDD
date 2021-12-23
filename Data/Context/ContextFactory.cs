using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //usando para criar as Migrações
            var connectionString = "Data Source=localhost;Initial Catalog=dbAPI;Persist Security Info=True;User ID=sa;Password=Feed@123;Connect Timeout=180;Encrypt=False;Current Language=Brazilian";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext> ();

            if (!optionsBuilder.IsConfigured)

            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
