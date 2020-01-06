﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCore.WebClient
{
    public interface IHttpClient : IDisposable
    {
        event EventHandler OnBeforeRequest;

        void AddHeader(string name, string value);

        void RemoveHeader(string name);

        Task<HttpResponseMessage> GetAsync(string requestUri);

        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);

        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);

        Task<HttpResponseMessage> DeleteAsync(string requestUri);

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);

    }
}
