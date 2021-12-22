using Domain.Entities;
using Domain.Services.user;
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


        [HttpPost]
        public async Task<ActionResult> Post([FromServices] IUserService service, UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await service.Post(user));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromServices] IUserService service, UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await service.Put(user));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete([FromServices] IUserService service, Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await service.Delete(Id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }



    }
}
