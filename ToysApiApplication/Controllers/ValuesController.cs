using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToysApplication.Interfaces;

namespace ToysApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IEmail _email;

        public ValuesController(IEmail email)
        {
            _email = email;
        }

        // GET api/values
        [HttpGet]
        public void Get(string email)
        {
            _email.Subject = "Uspesna registracija";
           _email.ToEmail = email;
            _email.Body = "Uspešno ste se registrovali na Toys";
           // _email.Send();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
