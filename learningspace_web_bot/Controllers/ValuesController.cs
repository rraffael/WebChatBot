using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learningspace_web_bot.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace learningspace_web_bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET |Route: api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new Value { ValueDescription = "First Description Example" });
        }

        // GET |Route: api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST |Route: api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT |Route: api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // Route: DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
