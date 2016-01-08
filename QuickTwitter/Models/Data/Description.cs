using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTwitter.Models.Data
{
    public class Description
    {
        [JsonProperty("urls")]
        public string Urls { get; set; }
    }
}
