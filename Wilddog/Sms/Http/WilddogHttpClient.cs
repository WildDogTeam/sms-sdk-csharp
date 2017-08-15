using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wilddog.Sms.Util;
namespace Wilddog.Sms.Http
{
    public class WilddogHttpClient
    {
        /// <summary>
        /// The http client.
        /// </summary>
        private readonly HttpClient HttpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Wilddog.Sms.Http.WilddogHttpClient"/> class.
        /// </summary>
        public WilddogHttpClient()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("UserAgent", Const.WILDDOG_SMS_USER_AGENT);
        }

        /// <summary>
        /// Processes the response.
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="responseTask">Response task.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private T ProcessResponse<T>(Task<HttpResponseMessage> responseTask) where T : Response
        {
            HttpResponseMessage httpResponse = responseTask.Result;
            if (HttpStatusCode.OK.Equals(httpResponse.StatusCode))
            {
                Task<string> responseBody = httpResponse.Content.ReadAsStringAsync();
                Response response = JsonConvert.DeserializeObject<T>(responseBody.Result);
                return (T)response;
            }
            else if (HttpStatusCode.BadRequest.Equals(httpResponse.StatusCode)
               || HttpStatusCode.InternalServerError.Equals(httpResponse.StatusCode))
            {
                Task<string> responseBody = httpResponse.Content.ReadAsStringAsync();
                WilddogError wilddogError = JsonConvert.DeserializeObject<WilddogError>(responseBody.Result);
                return (T)Activator.CreateInstance(typeof(T), new object[] { false, wilddogError });
            }
            else
            {
                WilddogError wilddogError = new WilddogError(httpResponse.StatusCode.ToString(), "");
                return (T)Activator.CreateInstance(typeof(T), new object[] { false, wilddogError });
            }
        }

        /// <summary>
        /// Dos the post.
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="url">URL.</param>
        /// <param name="content">Content.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T DoPost<T>(string url, HttpContent content) where T : Response
        {
            Task<HttpResponseMessage> responseTask = HttpClient.PostAsync(url, content);
            return ProcessResponse<T>(responseTask);
        }

        /// <summary>
        /// Dos the get.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public T DoGet<T>(string url) where T : Response
        {
            Task<HttpResponseMessage> responseTask = HttpClient.GetAsync(url);
            return ProcessResponse<T>(responseTask);
        }
    }
}
