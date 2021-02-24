using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace web_api_gateway.Infrastructure
{
    public abstract class ApiClientBase
    {
        protected ApiClientBase()
        {
            HttpClient = new HttpClient();
        }

        public HttpClient HttpClient { get; }

        protected virtual HttpRequestMessage CreateRequestMessage(Uri uri)
        {
            if (uri is null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return request;
        }

        public virtual Task<T> PostAsync<T>(string resourceUri)
        {
            return PostAsync<T>(resourceUri, null);
        }

        public virtual async Task<T> PostAsync<T>(string resourceUri, object requestBody)
        {
            if (string.IsNullOrWhiteSpace(resourceUri))
            {
                throw new ArgumentException($"'{nameof(resourceUri)}' cannot be null or whitespace", nameof(resourceUri));
            }

            using var request = new HttpRequestMessage(HttpMethod.Post, resourceUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (requestBody != null)
            {
                var json = JsonConvert.SerializeObject(requestBody);
                var messageContent = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = messageContent;
            }

            using var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        
        public virtual async Task<T> GetAsync<T>(string resourceUri)
        {
            if (string.IsNullOrWhiteSpace(resourceUri))
            {
                throw new ArgumentException($"'{nameof(resourceUri)}' cannot be null or whitespace", nameof(resourceUri));
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, resourceUri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

    }
}
