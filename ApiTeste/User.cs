

using Domain.Entities;
using System;
using Xunit;

namespace ApiTeste
{
   public class User
    {

        [Fact]

        public void RetornaListaDeUsuarios()
        {

            //Arrange

            var usuario = new UserEntity();
            usuario.Id = Guid.NewGuid();
            usuario.Nome = "Maycon Leles";
            usuario.Email = "Maycon91leles@hotmail.com";
            
            //act


            //Assert
        }

    }
}
