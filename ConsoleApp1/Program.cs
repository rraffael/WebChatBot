
using Newtonsoft.Json;
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
            var res = helper.GetResponse("Local").GetAwaiter().GetResult();

            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}
