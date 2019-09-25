using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Conrec.Helper
{
    /// <summary>
    /// Use this helper to call Web Api
    /// </summary>
    public static class WebApiClientHelper
    {
        /// <summary>
        /// Generic request handler
        /// </summary>
        /// <param name="request">the request</param>
        /// <param name="uri">The name of method</param>
        /// <returns>The response</returns>
        public static T CallWebApiMethod<T>(string uri)
        {
            try
            {
                var url = new Uri(uri);
                //Get the response
                using (var handler = new HttpClientHandler {Credentials = SetCredential(url) })
                {
                    using (var httpclient = new HttpClient(handler))
                    {
                        httpclient.Timeout = TimeSpan.FromMinutes(30);

                        // TO DO: THIS IS FOR POST
                        //var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8,
                        //    "application/json");

                        using (var httpresponse = httpclient.GetAsync(url))
                        {
                            httpresponse.Result.EnsureSuccessStatusCode();                        
                            var message = httpresponse.Result.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<T>(message.Result, GetJsonSettings());
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured when sending a request to {uri}", ex);
            }

        }

        /// <summary>
        /// Get the credentials for the call back
        /// </summary>
        /// <returns>A network credential </returns>
        private static NetworkCredential SetCredential(Uri url)
        {
            if (url.IsLoopback)
            {
                return CredentialCache.DefaultNetworkCredentials;
            }
            return CredentialCache.DefaultNetworkCredentials;         
        }

        /// <summary>
        /// Get the standard JSON serialisation settings
        /// </summary>
        /// <returns>A JsoSerializerSettings object </returns>
        private static JsonSerializerSettings GetJsonSettings()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            return jsonSerializerSettings;
        }
    }
}