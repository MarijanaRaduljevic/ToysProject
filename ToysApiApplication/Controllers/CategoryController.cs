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
    public class CategoryController : Controller
    {

        private readonly IGetCategoryCommand _getCategory;
        private readonly IDeleteCategoryCommand _deleteCategory;
        private readonly ICreateCategoryCommand _createCategory;
        private readonly IEditCategoryCommand _editCategory;

        public CategoryController(IGetCategoryCommand getCategory, IDeleteCategoryCommand deleteCategory, ICreateCategoryCommand createCategory, IEditCategoryCommand editCategory)
        {
            _getCategory = getCategory;
            _deleteCategory = deleteCategory;
            _createCategory = createCategory;
            _editCategory = editCategory;
        }





        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<GetCategoryDto>> Get([FromQuery] CategorySearches search)
        {
            try
            {
                var category = _getCategory.Execute(search);
                return Ok(category);
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
        public IActionResult Post([FromBody] CreateCategoryDto dto)
        {
            try
            {
                _createCategory.Execute(dto);
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
        public IActionResult Put(int id, [FromBody] CreateCategoryDto dto)
        {
            dto.Id = id;
            try
            {

                _editCategory.Execute(dto);
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
                _deleteCategory.Execute(id);
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
