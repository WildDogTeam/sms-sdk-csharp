﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
namespace Wilddog.Sms.Http
{
    public class WilddogHttpClient
    {
        private System.Net.Http.HttpClient client;

        public WilddogHttpClient()
        {
            client = new System.Net.Http.HttpClient();
        }

        /// <summary>
        /// Processes the response.
        /// </summary>
        /// <returns>The response body.</returns>
        /// <param name="responseTask">Response task.</param>
        private String processResponse(Task<HttpResponseMessage> responseTask)
        {
            HttpResponseMessage response = responseTask.Result;
            if (HttpStatusCode.OK.Equals(response.StatusCode)
               || HttpStatusCode.BadRequest.Equals(response.StatusCode)
               || HttpStatusCode.InternalServerError.Equals(response.StatusCode))
            {
                Task<String> responseBody = response.Content.ReadAsStringAsync();
                return responseBody.Result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Dos the post.
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="url">URL.</param>
        /// <param name="content">Content.</param>
        public String doPost(String url, HttpContent content)
        {
            Task<HttpResponseMessage> responseTask = client.PostAsync(url, content);
            return processResponse(responseTask);
        }

        /// <summary>
        /// Dos the get.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="url">URL.</param>
        public String doGet(String url)
        {
            Task<HttpResponseMessage> responseTask = client.GetAsync(url);
            return processResponse(responseTask);
        }
    }
}
