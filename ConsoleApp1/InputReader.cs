using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App2
{
    public class InputReader
    {
        public string GetInput(string inputJson)
        {
            string output = "";
            //string json = "{\"name\":\"Anthony\",\"dialog\":\"Alou\"}";    /// teste

            JObject jObject = JObject.Parse(inputJson);
            string name = (string)jObject.SelectToken("name");
            string dialog = (string)jObject.SelectToken("dialog");
            output = dialog;

            return output;
        }
    }
}


