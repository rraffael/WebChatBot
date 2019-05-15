using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Models
{
    public class ConversationHelper
    {
        private readonly string _Server;
        private readonly NetworkCredential _NetCredential;
        public ConversationHelper(string workSpaceId, string userId, string password)
        {
            _Server = string.Format("https://gateway.watsonplatform.net/conversation/api/v1/workspaces/{0}/message?version={1}", workSpaceId, DateTime.Today.ToString("yyyy-MM-dd"));
            _NetCredential = new NetworkCredential(userId, password);
        }
        public async Task<string> GetResponse(string input, string context = null)
        {
            string req = null;
            if (string.IsNullOrEmpty(context)) req = "{\"input\": {\"text\": \"" + input + "\"}, \"alternate_intents\": true}";
            else req = "{\"input\": {\"text\": \"" + input + "\"}, \"alternate_intents\": true}, \"context\": \"" + context + "\"";
            using (var handler = new HttpClientHandler
            {
                Credentials = _NetCredential
            })
            using (var client = new HttpClient(handler))
            {
                var cont = new HttpRequestMessage();
                cont.Content = new StringContent(req.ToString(), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(_Server, cont.Content);
                JObject jsonRes = JObject.Parse(await result.Content.ReadAsStringAsync());
                JObject response = new JObject();
                response.Add("input",jsonRes.GetValue("input"));
                response.Add("context",jsonRes.GetValue("context"));
                return response.ToString();
            }
        }
    }
}


