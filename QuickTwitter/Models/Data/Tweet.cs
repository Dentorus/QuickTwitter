using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTwitter.Models.Data
{
    public class Tweet
    {
        [JsonProperty("coordinates")]
        public string Coordinates { get; set; }

        [JsonProperty("favorited")]
        public bool IsFavorited { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        private string _createdAt;

        public string ExpandedCreatedAt
        {
            get
            {
                var data = CreatedAt.Split(' ');

                string Weekday = data[0];
                string Month = data[1];
                string Day = data[2];
                string Year = data[5];

                string Time = data[3];

                return String.Format("{0} {1} {2}", Time, Month, Day);
            }
            set { _createdAt = CreatedAt; }
        }

        [JsonProperty("id_str")]
        public string IdStr { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("in_reply_to_user_id_str")]
        public string InReplyToUserIdStr { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("retweet_count")]
        public int RetweetCount { get; set; }

        [JsonProperty("in_reply_to_status_id_str")]
        public string InReplyToStatusIdStr { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("retweeted")]
        public bool Retweeted { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("in_reply_to_screen_name")]
        public string InReplyToScreenName { get; set; }

        [JsonProperty("source")]
        public string Sourse { get; set; }

        [JsonProperty("in_reply_to_status_id")]
        public string InReplyToStatusId { get; set; }

        [JsonProperty("extended_entities")]
        public ExtendedEntities ExtendedEntities { get; set; }

    }
}
