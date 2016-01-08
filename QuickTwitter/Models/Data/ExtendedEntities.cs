using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTwitter.Models.Data
{
    public class ExtendedEntities
    {
        [JsonProperty("media")]
        public Media[] Media { get; set; }
    }
}
