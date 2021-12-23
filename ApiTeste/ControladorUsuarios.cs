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

          
    }
}
