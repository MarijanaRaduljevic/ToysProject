using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysApplication.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToysApiApplication.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly ICreateRoleCommand _createRole;
        private readonly IEditRoleCommand _editRole;
        private readonly IDeleteRoleCommand _deleteRole;
        private readonly IGetRoleCommand _detRole;

        public RoleController(ICreateRoleCommand createRole, IEditRoleCommand editRole, IDeleteRoleCommand deleteRole, IGetRoleCommand detRole)
        {
            _createRole = createRole;
            _editRole = editRole;
            _deleteRole = deleteRole;
            _detRole = detRole;
        }







        // GET: api/<controller>
        [HttpGet]
        public ActionResult <IEnumerable<GetRoleDto>> Get([FromQuery] RoleSearches search)
        {
            try
            {
                var role = _detRole.Execute(search);
                return Ok(role);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CreateRoleDto dto)
        {
            try
            {
                _createRole.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }

            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CreateRoleDto dto)
        {
            dto.Id = id;
            try
            {

               _editRole.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Category doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteRole.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Došlo je do greške, molimo pokušajte kasnije.");
            }
        }
    }
}
