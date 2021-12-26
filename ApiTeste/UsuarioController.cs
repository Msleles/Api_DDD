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
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiTeste
{
   public class UsuarioController
    {


        private static MyContext ContextFake()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                    .UseInMemoryDatabase("MyContext")
                    .Options;
            var contexto = new MyContext(options);
            return contexto;
        }


        [Fact]
        public void UsersControllerMetodoPost()
        {

            //Arrange
            var mock = new Mock<IRepository<UserEntity>>();
            var repositorio = new UserService(mock.Object);
            var controlador = new UsersController(repositorio);
            var modelo = new UserEntity();
            modelo.Id = Guid.NewGuid();
            modelo.Nome = "MayconLeles";
            modelo.Email = "Maycon91leles@hotmail.com";

            //act
            var ret =  controlador.Post(modelo);

            //Assert
            Assert.NotNull(ret);
            Assert.IsType<Task<ActionResult>>(ret);          
        }

        [Fact]
        public void UsersControllerMetodoGetAll()
        {

            //Arrange
            //banco InMemory

            var mock = new Mock<IRepository<UserEntity>>();
            var repositorio = new UserService(mock.Object);
            var controlador = new UsersController(repositorio);

            MyContext contexto = ContextFake();

            var modelo = new UserEntity();
            modelo.Id = Guid.NewGuid();
            modelo.Nome = "AnaLuiza";
            modelo.Email = "Ana@123";
            contexto.Users.Add(modelo);
            contexto.SaveChanges();

            //Act
            var result = controlador.GetAll();


            //Assert
            Assert.IsType<Task<ActionResult>>(result);

        }

      

        [Fact]
        public void UsersControllerMetodoDelete()
        {
            //Arrange
            var mock = new Mock<IRepository<UserEntity>>();
            var repo = new UserService(mock.Object);
            var controle = new UsersController(repo);

            var contexto = ContextFake();
            var user = new UserEntity();
            {
                user.Id = Guid.NewGuid();
                user.Nome = "Joao Batista";
                user.Email = "Joao@123";
                contexto.Users.Add(user);
                contexto.SaveChanges();
            }

            //Act
            var usuario = contexto.Users
                    .Where(b => b.Nome == "Joao Batista")
                    .FirstOrDefault();

            var del = controle.Delete(usuario.Id);


            //Assert
            Assert.Equal("Joao Batista", usuario.Nome);
            Assert.NotNull(usuario);
            Assert.IsType<Task<ActionResult>>(del);
            
        }
    }
}
