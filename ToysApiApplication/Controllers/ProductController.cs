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
    public class ProductController : Controller
    {

        private readonly ICreateProductCommand _createProduct;
        private readonly IGetProductCommand _getProduct;
        private readonly IDeleteProductCommand _deleteProduct;
        private readonly IEditProductCommand _editProduct;
        private readonly IGetOneProductCommand _getOneProduct;

        public ProductController(ICreateProductCommand createProduct, IGetProductCommand getProduct, IDeleteProductCommand deleteProduct, IEditProductCommand editProduct, IGetOneProductCommand getOneProduct)
        {
            _createProduct = createProduct;
            _getProduct = getProduct;
            _deleteProduct = deleteProduct;
            _editProduct = editProduct;
            _getOneProduct = getOneProduct;
        }












        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<GetProductDto>> Get([FromQuery] ProductSearches search)
        {
            try
            {
                var product = _getProduct.Execute(search);
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Doslo je do greske, molimo pokusajte kasnije.");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            try
            {
                var one = _getOneProduct.Execute(id);
                return Ok(one);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Product doesn't exist.")
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
        public IActionResult Post([FromBody] CreateProductDto dto)
        {
            try
            {
                _createProduct.Execute(dto);
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
        public IActionResult Put(int id, [FromBody] CreateProductDto dto)
        {
            dto.Id = id;
            try
            {

                _editProduct.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Product doesn't exist.")
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
                _deleteProduct.Execute(id);
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
