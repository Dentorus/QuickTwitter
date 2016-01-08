using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuickTwitter.Models.Requests
{
    public class ObtainBearerTokenRequest
    {
        public ObtainBearerTokenRequest()
        {

        }

        public async Task<String> CreateRequest(string CodedTokensCredentials)
        {
            string uri = "https://api.twitter.com/oauth2/token";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Host", "api.twitter.com");
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + CodedTokensCredentials);

            client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded;charset=UTF-8");

            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            var requestContent = new FormUrlEncodedContent(postData);
            HttpResponseMessage responce = new HttpResponseMessage();

            while (true)
            {
                try
                {
                    responce = await client.PostAsync(uri, requestContent);
                    break;
                }
                catch { }
            }

            var data = await responce.Content.ReadAsByteArrayAsync();
            byte[] decompress = LoginHelper.Decompress(data);

            return System.Text.ASCIIEncoding.ASCII.GetString(decompress);
        }


    }
}
