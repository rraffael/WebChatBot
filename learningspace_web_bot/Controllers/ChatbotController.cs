using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learningspace_web_bot.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace learningspace_web_bot.Controllers
{
    [Route("api/[controller]")]
    public class ChatbotController : ControllerBase
    {
        AssistantHelper _assistantHelper;

        public ChatbotController()
        {
            _assistantHelper = new AssistantHelper();
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [SwaggerOperation(
            Summary ="Envia uma mensagem para o chatbot.",
            Produces = new[] { "application/json" }
            )]
        public IActionResult Post([FromBody] Question question)
        {
            string response = _assistantHelper.getResponse(question.text);

            return Created("uri1", response);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
