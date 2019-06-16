using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToysApplication.Commands;
using ToysApplication.DTO;
using ToysApplication.Exceptions;
using ToysApplication.Helpers;
using ToysApplication.Searches;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToysApiApplication.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {

        private readonly IDeleteImageCommand _deleteImage;
        private readonly IGetImageCommand _getImage;
        private readonly ICreateImageCommand _createImage;

        public ImageController(IDeleteImageCommand deleteImage, IGetImageCommand getImage, ICreateImageCommand createImage)
        {
            _deleteImage = deleteImage;
            _getImage = getImage;
            _createImage = createImage;
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
        public IActionResult Post([FromForm] CreateImageDto dto)
        {
            var ext = Path.GetExtension(dto.Image.FileName);
            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }
            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", newFileName);
                dto.Image.CopyTo(new FileStream(filePath, FileMode.Create));


                var image = new CreateImageDto
                {
                    Alt = dto.Alt,
                    Src = newFileName,
                    Title = dto.Title
                };
                _createImage.Execute(image);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

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
