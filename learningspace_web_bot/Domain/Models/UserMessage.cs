using IBM.WatsonDeveloperCloud.Assistant.v1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learningspace_web_bot.Domain.Models
{
    public class UserMessage
    {
        public string Text { get; set; }
        public Context Context { get; set; }
    }
}
