using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learningspace_web_bot.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace learningspace_web_bot.Controllers
{
    [Route("WebBot")]
    [ApiController]
    public class WebBotController : ControllerBase
    {

        //Dados passados pela URL, Necessita inserir [FromBody] no parâmetro e fazer funcionar
        #region Post "WebBot"
        [HttpPost]
        [Route("")]
        public IActionResult Index(string answer)
        {
            return Ok(JsonConvert.SerializeObject(answer));
        }
        #endregion

        //#region GET "WebBot/{id}"
        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}
        //#endregion

        //#region POST "WebBot"
        //[HttpPost]
        //[Route("")]
        //public void Post([FromBody] string value)
        //{
        //}
        //#endregion

        //#region PUT "WebBot/{id}
        //[HttpPut]
        //[Route("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        //#endregion

        //#region DELETE "WebBot/{id}"
        //[HttpDelete]
        //[Route("{id}")]
        //public void Delete(int id)
        //{
        //}
        //#endregion


    }
}
