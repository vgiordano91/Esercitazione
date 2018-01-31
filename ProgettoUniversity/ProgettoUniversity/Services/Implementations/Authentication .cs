using Newtonsoft.Json;
using ProgettoUniversity.Models.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProgettoUniversity.Services.Implementations
{
    public class Authentication
    {
        public async Task<string> GetToken()
        {
            string token = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                    var connectionData = new[] {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", Constants.DOMEC_API_USERNAME) ,
                        new KeyValuePair<string, string>("password", Constants.DOMEC_API_PASSWORD)
                    };
                    var loginData = new FormUrlEncodedContent(connectionData);
                    HttpResponseMessage response = await client.PostAsync(Constants.API_TOKEN, loginData);

                    string jsonMessage;
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }

                    AuthenticationTokenViewModel at = JsonConvert.DeserializeObject<AuthenticationTokenViewModel>(jsonMessage);
                    token = at.access_token;
                }
            }
            catch (Exception ex)
            {
                //_logger.Error(string.Format("-- DigitalCardService - GetToken ERROR : {0} {1}" + ex.Message, ex.StackTrace));
                throw new Exception(ex.StackTrace, ex);
            }
            //_logger.Info("GetToken completed successfully");
            return token;
        }

    }
}
