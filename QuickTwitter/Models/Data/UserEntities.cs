using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTwitter.Models.Data
{
    public class UserEntities
    {
        [JsonProperty("entities")]
        public Description Description { get; set; }
    }

}
