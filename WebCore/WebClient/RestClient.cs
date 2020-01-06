﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCore.WebClient
{
    public class RestClient
    {
        protected readonly IHttpClient client;

        public RestClient(IHttpClient client)
        {
            this.client = client;
        }

        public void AddAuthorizationHeader(string value)
        {
            client.AddAuthorizationHeader(value);
        }

        public HttpResponseMessage Get(RestRequest request)
        {
            request.VisitClient(client);

            var response = client.GetAsync(request.Url).Result;
            VerifyResponse(response);
            return response;
        }

        public T Get<T>(RestRequest request)
        {
            request.VisitClient(client);

            using (var response = client.GetAsync(request.Url).Result)
            {
                VerifyResponse(response);
                return ReadContentAsync<T>(response).Result;
            }
        }

        public HttpResponseMessage Post(RestRequest request)
        {
            if (request.Content == null)
                throw new ArgumentNullException("Request content should be filled");

            request.VisitClient(client);

            using (var response = client.PostAsync(request.Url, request.Content).Result)
            {
                VerifyResponse(response);
                return response;
            }
        }

        public T Post<T>(RestRequest request)
        {
            if (request.Content == null)
                throw new ArgumentNullException("Request content should be filled");

            request.VisitClient(client);

            using (var response = client.PostAsync(request.Url, request.Content).Result)
            {
                VerifyResponse(response);
                return ReadContentAsync<T>(response).Result;
            }
        }

        public T Put<T>(RestRequest request)
        {
            if (request.Content == null)
                throw new ArgumentNullException("Request content should be filled");

            request.VisitClient(client);

            using (var response = client.PutAsync(request.Url, request.Content).Result)
            {
                VerifyResponse(response);
                return ReadContentAsync<T>(response).Result;
            }
        }

        public void Delete(RestRequest request)
        {
            request.VisitClient(client);

            using (var response = client.DeleteAsync(request.Url).Result)
            {
                VerifyResponse(response);
            }
        }

        private void VerifyResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var error = ReadContentAsync<ErrorResult>(response).Result;
                throw new ErrorResponseException(error, response.StatusCode);
            }
        }

        private static async Task<T> ReadContentAsync<T>(HttpResponseMessage response)
        {
            try
            {
                return await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Invalid response: '{result}'", e);
            }
        }
    }
}
