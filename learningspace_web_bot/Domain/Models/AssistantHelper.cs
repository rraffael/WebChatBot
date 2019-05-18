using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBM.WatsonDeveloperCloud.Assistant.v1;
using IBM.WatsonDeveloperCloud.Assistant.v1.Model;
using IBM.WatsonDeveloperCloud.Util;
using Newtonsoft.Json.Linq;

namespace learningspace_web_bot.Domain.Models
{
    public class AssistantHelper
    {
        AssistantService _assistant;
        readonly string workspaceID = "9194a4df-796d-4e43-ad12-46b1f8a2c400";

        public AssistantHelper()
        {
            TokenOptions iamAssistantTokenOptions = new TokenOptions()
            {
                IamApiKey = "T8PnPM5Se2IsR3grU9epslCpqqcZVgcJu8bKxBax7x0o",
                ServiceUrl = "https://gateway.watsonplatform.net/assistant/api",
            };

            _assistant = new AssistantService(iamAssistantTokenOptions, "2019-02-28");
        }

        public string getResponse(UserMessage userMessage)
        {
            var messageRequest = new MessageRequest()
            {
                Input = new InputData()
                {
                    Text = userMessage.Text,
                },
                Context = userMessage.Context,
                
            };

            var result = _assistant.Message(workspaceID, messageRequest);
            JObject json = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(result.ResponseJson);

            JObject response = new JObject(
                                    new JProperty("output", json.GetValue("output")),
                                    new JProperty("context",json.GetValue("context"))
                                    );

            return response.ToString();
            //return result.ResponseJson;
            
        }

        

        




    }
}
