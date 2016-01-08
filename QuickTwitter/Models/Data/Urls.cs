using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTwitter.Models.Data
{
    public class Urls
    {
        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("indices")]
        public string[] Indices { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }
    }
}
