using Appication.Controllers;
using Domain.Entities;
using Domain.Services.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTeste
{
   public class ControladorUsuarios
    {

        private readonly UsersController _userConroller;
        protected readonly IUserService _userService;

        public ControladorUsuarios(UsersController userConroller, IUserService userService)
        {
            _userConroller = userConroller;
            _userService = userService;
        }

        [Fact]
        public void GetUsuarios()
        {
            UserEntity user = new UserEntity();
            {
                user.Id = Guid.NewGuid();
                user.Nome = "Maycon Leles";
                user.Email = "Maycon91leles@hotmail.com";
            }
            var ActionResult = _userConroller.GetAll(_userService);

            Assert.NotNull(ActionResult);           
            Assert.True(ActionResult.IsCompletedSuccessfully);
        }

       
    }
}
