using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace learningspace_web_bot.Controllers
{
    public class WebBotAPIController : Controller
    {
        private ConversationHelper helper = new ConversationHelper("3c1a7590-d8ce-4fe8-9061-d3731b06d386", "apikey", "J9vgtAyW_gpQH1A2ZqupBoGvrjRC6q_cL_rPZX7xzDDd");

        [Route("GetResult")]
        [HttpGet]
        public ActionResult GetResult(JsonResult answer)
        {
            var res = this.WatsonResponse(answer.Value.ToString());
            return Ok(res);
        }

        private string WatsonResponse(string inputJson)
        {
            var res = helper.GetResponse(inputJson).GetAwaiter().GetResult();
            JObject jObject = JObject.Parse(res);
            string text = (string)jObject.SelectToken("output").SelectToken("text")[0];
            return text;
        }
    }
}