﻿using Domain.Services.user;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Appication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {

                return StatusCode((int) HttpStatusCode.InternalServerError,e.Message);
            }
        }
    }
}
