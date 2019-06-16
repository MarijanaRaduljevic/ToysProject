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
    public class UserController : Controller
    {
        private readonly ICreateUserCommand _createUser;
        private readonly IDeleteUserCommand _deleteUser;
        private readonly IEditUserCommand _editUser;
        private readonly IGetUserCommand _getUser;
        private readonly IGetOneUserCommand _getOne;

        public UserController(ICreateUserCommand createUser, IDeleteUserCommand deleteUser, IEditUserCommand editUser, IGetUserCommand getUser, IGetOneUserCommand getOne)
        {
            _createUser = createUser;
            _deleteUser = deleteUser;
            _editUser = editUser;
            _getUser = getUser;
            _getOne = getOne;
        }








        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<GetUserDto>> Get([FromQuery] UserSearches search)
        {
            try
            {
                var user = _getUser.Execute(search);
                return Ok(user);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
            
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var oneUser = _getOne.Execute(id);
                return Ok(oneUser);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "User doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);

            }

            catch (Exception e)
            {
                return StatusCode(500, "Doslo je do greske, molimo pokusajte kasnije.");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CreateUserDto dto)
        {
            try
            {
                _createUser.Execute(dto);
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
        public IActionResult Put(int id, [FromBody]CreateUserDto dto)
        {
            dto.Id = id;
            try
            {
                _editUser.Execute(dto);
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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteUser.Execute(id);
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
