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
    public class ImageController : Controller
    {

        private readonly IDeleteImageCommand _deleteImage;
        private readonly IGetImageCommand _getImage;

        public ImageController(IDeleteImageCommand deleteImage, IGetImageCommand getImage)
        {
            _deleteImage = deleteImage;
            _getImage = getImage;
        }



        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<GetImageDto>> Get([FromQuery] ImageSearches search)
        {
            try
            {
                var image = _getImage.Execute(search);
                return Ok(image);
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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteImage.Execute(id);
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
