using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProgettoUniversity.Models.API;
using ProgettoUniversity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoUniversity.Services.Implementations
{
    public class StoredValueCardService : IStoredValueCardService
    {

        private Authentication _authentication;
        private ILogger<StoredValueCardService> _logger;

        public StoredValueCardService(ILoggerFactory loggerFactory, Authentication authentication)
        {
            _logger = loggerFactory.CreateLogger<StoredValueCardService>();
            _authentication = authentication;
        }

        public async Task<SVCOperationResultViewModel> Activate(SVCOperationViewModel model) {
            _logger.LogInformation(string.Format("-- ApiManager - Create started"));

            SVCOperationResultViewModel result = new SVCOperationResultViewModel(Constants.MSG_RESULT_STATUS_OK, Constants.MSG_RESULT_MESSAGE_OK, Constants.MSG_RESULT_CODE_OK);

            string jsonMessage = "";
            try
            {
                // Read token from ServerLogin
                string token = await _authentication.GetToken();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Read endpoint from CampaignType
                    string endpoint = Constants.API_ACTIVATE;

                    HttpResponseMessage response = await client.PutAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }
                    result = JsonConvert.DeserializeObject<SVCOperationResultViewModel>(jsonMessage);
                }
            }
            catch (System.Exception ex)
            {
                result.ResultMessage = ex.Message;
                result.ResultStatus = Constants.MSG_RESULT_STATUS_NOK;
                result.ResultCode = Constants.MSG_RESULT_CODE_KO;
            }
            return result;

        }

        public async Task<CreateResultViewModel> Create(int campaignID, decimal amount)
        {
            CreateResultViewModel result = new CreateResultViewModel(Constants.MSG_RESULT_STATUS_OK, Constants.MSG_RESULT_MESSAGE_OK, Constants.MSG_RESULT_CODE_OK);
            _logger.LogInformation(string.Format("-- ApiManager - Create started"));

            string jsonMessage = "";
            try
            {
                // Read token from ServerLogin
                string token = await _authentication.GetToken();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Read endpoint from CampaignType
                    string endpoint = Constants.API_CREATE;

                    dynamic body = new
                    {
                        CampaignID = campaignID,
                        CardValue = amount
                    };

                    HttpResponseMessage response = await client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }
                    result = JsonConvert.DeserializeObject<CreateResultViewModel>(jsonMessage);
                }
            }
            catch (Exception ex)
            {
                result.ResultMessage = ex.Message;
                result.ResultStatus = Constants.MSG_RESULT_STATUS_NOK;
                result.ResultCode = Constants.MSG_RESULT_CODE_KO;
            }
            
            return result;
        }

        public async Task<CardDetailViewModel> Status(string cardCode)
        {
            CardDetailViewModel result = new CardDetailViewModel(Constants.MSG_RESULT_STATUS_OK, Constants.MSG_RESULT_MESSAGE_OK, Constants.MSG_RESULT_CODE_OK);
            string jsonResult = "";
            try
            {
                // Login sulla piattaforma
                string token = await _authentication.GetToken();


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string query = string.Empty;
                    using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>("cardCode", cardCode),
                        new KeyValuePair<string, string>("shop", Constants.SHOP),
                        new KeyValuePair<string, string>("terminal", Constants.TERMINAL)
                    }))
                    {
                        query = content.ReadAsStringAsync().Result;
                    };

                    string request = Constants.API_STATUS + "?" + query;

                    //Ottengo la risposta dal server
                    HttpResponseMessage response = await client.GetAsync(request, HttpCompletionOption.ResponseContentRead);
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonResult = new StreamReader(responseStream).ReadToEnd();
                    }
                    result = BuildCardDetail(jsonResult);
                }
            }
            catch (Exception ex)
            {
                result.ResultMessage = ex.Message;
                result.ResultStatus = Constants.MSG_RESULT_STATUS_NOK;
                result.ResultCode = Constants.MSG_RESULT_CODE_KO;
            }
            return result;
        }

        private CardDetailViewModel BuildCardDetail(string json)
        {
            var result = JsonConvert.DeserializeObject<CardDetailViewModel>(json);
            return result;
        }

        public async Task<CardDetailViewModel> Balance(string cardCode)
        {
            CardDetailViewModel result = new CardDetailViewModel(Constants.MSG_RESULT_STATUS_OK, Constants.MSG_RESULT_MESSAGE_OK, Constants.MSG_RESULT_CODE_OK);
            string jsonResult = "";
            try
            {
                // Login sulla piattaforma
                string token = await _authentication.GetToken();


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string query = string.Empty;
                    using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>("cardCode", cardCode),
                        new KeyValuePair<string, string>("shop", Constants.SHOP),
                        new KeyValuePair<string, string>("terminal", Constants.TERMINAL)
                    }))
                    {
                        query = content.ReadAsStringAsync().Result;
                    };

                    string request = Constants.API_BALANCE + "?" + query;

                    //Ottengo la risposta dal server
                    HttpResponseMessage response = await client.GetAsync(request, HttpCompletionOption.ResponseContentRead);

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonResult = new StreamReader(responseStream).ReadToEnd();
                    }
                    result = BuildCardDetailBalance(jsonResult);
                }

            }
            catch (Exception ex)
            {
                result.ResultMessage = ex.Message;
                result.ResultStatus = Constants.MSG_RESULT_STATUS_NOK;
                result.ResultCode = Constants.MSG_RESULT_CODE_KO;
            }
            return result;
        }

        private CardDetailViewModel BuildCardDetailBalance(string json)
        {
            var result = JsonConvert.DeserializeObject<CardDetailViewModel>(json);
            return result;
        }

        public async Task<CardDetailViewModel> Transactions(string cardCode)
        {
            CardDetailViewModel result = new CardDetailViewModel(Constants.MSG_RESULT_STATUS_OK, Constants.MSG_RESULT_MESSAGE_OK, Constants.MSG_RESULT_CODE_OK);
            string jsonResult = "";
            try
            {
                // Login sulla piattaforma
                string token = await _authentication.GetToken();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string query = string.Empty;
                    using (var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>("cardCode", cardCode),
                        new KeyValuePair<string, string>("shop", Constants.SHOP),
                        new KeyValuePair<string, string>("terminal", Constants.TERMINAL)
                    }))
                    {
                        query = content.ReadAsStringAsync().Result;
                    };

                    string request = Constants.API_TRANSACTIONS + "?" + query;

                    //Ottengo la risposta dal server
                    HttpResponseMessage response = await client.GetAsync(request, HttpCompletionOption.ResponseContentRead);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(string.Format("-- DigitalCardService - Mobile GetStatus - Error: {0}", response.RequestMessage));
                    }
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonResult = new StreamReader(responseStream).ReadToEnd();
                    }

                    //CardDetailViewModel result = new CardDetailViewModel();
                    dynamic responseObj = JsonConvert.DeserializeObject<dynamic>(jsonResult);
                    List<TransactionInfo> transactions = responseObj["transactions"].ToObject<List<TransactionInfo>>();
                    foreach (var item in transactions)
                    {
                        result.Transactions.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                result.ResultMessage = ex.Message;
                result.ResultStatus = Constants.MSG_RESULT_STATUS_NOK;
                result.ResultCode = Constants.MSG_RESULT_CODE_KO;
            }
            return result;

        }

        public async Task<SVCResultViewModel> Associate(AssociateOperationViewModel model)
        {

            _logger.LogInformation(string.Format("-- ApiManager - Create started"));

            string jsonMessage = "";
            try
            {
                // Read token from ServerLogin
                string token = await _authentication.GetToken();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    model.Shop = Constants.SHOP;
                    model.Terminal = Constants.TERMINAL;

                    model.CardData.AuthorizationPin = "";
                    model.CardData.Approvals = "";
                    model.CardData.SecurityActivationToken = "";
                    model.CardData.Password = "";
                    

                    // Read endpoint from CampaignType
                    string endpoint = "svc/associate";

                    HttpResponseMessage response = await client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }

                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            var result = JsonConvert.DeserializeObject<SVCResultViewModel>(jsonMessage);
            return result;
        }

        public async Task<SVCResultViewModel> Charge(SVCChargeOperationViewModel model)
        {
            SVCResultViewModel result = new SVCResultViewModel(Constants.MSG_RESULT_MESSAGE_OK, Constants.MSG_RESULT_STATUS_OK, Constants.MSG_RESULT_CODE_OK);

            _logger.LogInformation(string.Format("-- ApiManager - Create started"));

            string jsonMessage = "";
            try
            {
                // Read token from ServerLogin
                string token = await _authentication.GetToken();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Read endpoint from CampaignType
                    string endpoint = Constants.API_CHARGE;

                    HttpResponseMessage response = await client.PutAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }
                    result = JsonConvert.DeserializeObject<SVCResultViewModel>(jsonMessage);
                }
            }
            catch (System.Exception ex)
            {
                result.ResultMessage = ex.Message;
                result.ResultStatus = Constants.MSG_RESULT_STATUS_NOK;
                result.ResultCode = Constants.MSG_RESULT_CODE_KO;

            }

            return result;

        }

        public async Task<SVCResultViewModel> Migrate(SVCMigrationOperationViewModel model)
        {
            SVCResultViewModel result = new SVCResultViewModel(Constants.MSG_RESULT_MESSAGE_OK, Constants.MSG_RESULT_STATUS_OK, Constants.MSG_RESULT_CODE_OK);

            _logger.LogInformation(string.Format("-- ApiManager - Create started"));

            string jsonMessage = "";
            try
            {
                // Read token from ServerLogin
                string token = await _authentication.GetToken();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //Read endpoint from CampaignType
                    string endpoint = Constants.API_MIGRATE;

                    HttpResponseMessage response = await client.PutAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    }
                    result = JsonConvert.DeserializeObject<SVCResultViewModel>(jsonMessage);
                }
            }
            catch (System.Exception ex)
            {
                result.ResultMessage = ex.Message;
                result.ResultStatus = Constants.MSG_RESULT_STATUS_NOK;
                result.ResultCode = Constants.MSG_RESULT_CODE_KO;

            }

            return result;

        }

    }
}
