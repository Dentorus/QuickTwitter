using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTwitter.Models.Data
{
    public class Entities
    {
        [JsonProperty("hashtags")]
        public Hashtags[] Hashtags { get; set; }

        [JsonProperty("symbols")]
        public string[] Symbols { get; set; }

        [JsonProperty("user_mentions")]
        public object[] UserMentions { get; set; }

        [JsonProperty("urls")]
        public Urls[] Urls { get; set; }

        [JsonProperty("media")]
        public Media[] Media { get; set; }
    }
}
