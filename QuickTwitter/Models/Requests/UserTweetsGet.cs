using Newtonsoft.Json;
using QuickTwitter.Models.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace QuickTwitter.Models.Requests
{
    public class UserTweetsGet
    {
        public UserTweetsGet()
        {

        }

        public async Task<BindableCollection<Tweet>> Execute(int count, bool excludeReplies, UserInfo info)
        {

            string uri = "https://api.twitter.com/1.1/statuses/user_timeline.json?count=" + count.ToString() + "&exclude_replies=" + excludeReplies.ToString() + "&" + "screen_name=" + "Bohdan2308";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Host", "api.twitter.com");
            client.DefaultRequestHeaders.Add("Authorization", info.TokenType + ' ' + info.AccessToken);

            HttpResponseMessage responce = new HttpResponseMessage();

            while (true)
            {
                try
                {
                    responce = await client.GetAsync(uri);
                    break;
                }
                catch { Debug.WriteLine("ERROR__IN__SENDING__REQUEST_!!!"); }
            }

            var ArchivedStringResponce = await responce.Content.ReadAsByteArrayAsync();
            byte[] decompress = LoginHelper.Decompress(ArchivedStringResponce);
            var StringResponce = System.Text.ASCIIEncoding.ASCII.GetString(decompress);

            var DeShieldedResponce = JsonConvert.DeserializeObject(StringResponce).ToString();


            Debug.WriteLine("LOOK HERE: " + DeShieldedResponce);

            var result = JsonConvert.DeserializeObject<List<Tweet>>(DeShieldedResponce);

            BindableCollection<Tweet> tweetsList = new BindableCollection<Tweet>();

            foreach (Tweet item in result)
            {
                tweetsList.Add(item);
            }

            return tweetsList;
        }
    }
}
