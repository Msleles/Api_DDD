

using Data.Context;
using Data.Repository;
using Domain.Entities;
using System;
using Xunit;

namespace ApiTeste
{
   public class User
    {

        protected readonly MyContext _context;



        public User(MyContext context)
        {
            _context = context;
        }

        [Fact]

        public void CadastrarUmNovoUsuario()
        {

            //Arrange
            UserEntity usuario = new UserEntity();
            usuario.Nome = "Maycon Leles";
            usuario.Email = "Maycon91leles@hotmail.com";
            usuario.CreateAt = DateTime.UtcNow;
            usuario.UpdateAt = DateTime.UtcNow;
            _context.Users.Add(usuario);
            _context.SaveChanges();

            //act
            var baseRepo = new BaseRepository<UserEntity>(_context);
            _ = baseRepo.SelectAsync();

            //Assert
            Assert.Equal(usuario.ToString(), baseRepo.ToString());
        }

    }
}
