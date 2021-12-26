
using Domain.Entities;
using Domain.Services.User;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TypePeopleController : ControllerBase
    {

        private ITypePeopleService _service;

        public TypePeopleController(ITypePeopleService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{Id}", Name = "GetDataWithId")]
        public async Task<ActionResult> Get(Guid Id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                return Ok(await _service.Get(Id));

            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TypePeople type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(type);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetDataWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult> Put(TypePeople type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Put(type));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(Id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
