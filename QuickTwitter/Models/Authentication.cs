using QuickTwitter.Models.Data;
using QuickTwitter.Models.Requests;
using System;
using System.Threading.Tasks;
using Windows.Data.Json;


namespace QuickTwitter.Models
{
    public class Authentication
    {
        public const string OAuthConsumerKey = "a0YshIoCwgmpub2X7RNIIP0y5";
        public const string OAuthConsumerSecret = "U2zddEWuMwb3T4qTW1if8ajwNPymdxFLM8gIZs8HwRpJp5fXzr";
        public const string OAuthVersion = "1.0";

        public async Task<UserInfo> Login()
        {
            /// <summary>
            /// RFC 1738 encoded consumer key and secret (does not change)
            /// this step should still be performed in case the format of those values changes in the future
            /// </summary>

            string EncodedConsumerKey = Uri.EscapeDataString(OAuthConsumerKey);
            string EncodedConsumerSecret = Uri.EscapeDataString(OAuthConsumerSecret);

            //Concatenate the encoded consumer key, a colon character ":", and the encoded consumer secret into a single string.
            string TokensCredentials = EncodedConsumerKey + ":" + EncodedConsumerSecret;

            //Base64 encode the TokenCredentials
            LoginHelper helper = new LoginHelper();
            string CodedTokensCredentials = helper.Base64Encode(TokensCredentials);

            //Create request

            ObtainBearerTokenRequest bearerRequest = new ObtainBearerTokenRequest();
            string bearerResponce = await bearerRequest.CreateRequest(CodedTokensCredentials);

            JsonValue jsonValue = JsonValue.Parse(bearerResponce);
            string TokenType = jsonValue.GetObject().GetNamedString("token_type");
            string AccessToken = jsonValue.GetObject().GetNamedString("access_token");

            return new UserInfo { OAuthConsumerKey = OAuthConsumerKey, OAuthConsumerSecret = OAuthConsumerSecret, TokenType = TokenType, AccessToken = AccessToken };

        }
    }
}
