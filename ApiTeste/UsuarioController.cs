using Data.Context;
using Domain.Entities;
using Domain.Services.user;
using Microsoft.EntityFrameworkCore;
using System;
using Services.Service;
using Xunit;
using Domain.Interfaces;
using Appication.Controllers;
using Data.Repository;
using System.Threading.Tasks;

namespace ApiTeste
{
   public class UsuarioController
    {

        [Fact]

        public void TestaMetodoGetAll()
        {

            //Arrange         
        //banco InMemory
        var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase("MyContext")
                .Options;
            var contexto = new MyContext(options);
          

             var user = new UserEntity();
            user.Id = Guid.NewGuid();
            user.Nome = "MayconLeles";
            user.Email = "teste@teste";

            var user1 = new UserEntity();
            user1.Id = Guid.NewGuid();
            user1.Nome = "fulanoDeTal";
            user1.Email = "teste@teste1";

           
            contexto.Users.Add(user);
            contexto.Users.Add(user1);
            contexto.SaveChanges();


            var repo = new BaseRepository<UserEntity>(contexto);
            var usuarios =  repo.SelectAsync();

     
            //assert
            
            Assert.NotNull(usuarios);
            
        }

    }
}
