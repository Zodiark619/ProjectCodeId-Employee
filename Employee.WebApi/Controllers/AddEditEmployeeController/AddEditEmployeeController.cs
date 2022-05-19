using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.WebApi.Controllers.AddEditEmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEditEmployeeController : ControllerBase
    {
        // GET: api/<AddEditEmployeeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddEditEmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddEditEmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<AddEditEmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddEditEmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
