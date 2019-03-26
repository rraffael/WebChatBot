
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace App2
{ 

    class Program
    {
        static void Main(string[] args)
        {
            
            ConversationHelper helper = new ConversationHelper("3c1a7590-d8ce-4fe8-9061-d3731b06d386", "apikey", "J9vgtAyW_gpQH1A2ZqupBoGvrjRC6q_cL_rPZX7xzDDd");

            var resposta = Console.ReadLine();
            while(resposta != "0"){
                string test = resposta.ToString();
                var res = helper.GetResponse(test).GetAwaiter().GetResult();
                JObject jObject = JObject.Parse(res);
                string text = (string)jObject.SelectToken("output").SelectToken("text")[0];

                Console.WriteLine("\n");
                Console.WriteLine(text);
                resposta = Console.ReadLine();
            }
            Console.WriteLine("\n");
            Console.WriteLine("Volte sempre");
            Console.ReadKey();
        }
    }
}
