using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ejuromag.API
{
    static class HTTPConnection<T> where T : class
    {
        public async static Task<T?> Get(string url)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = await client.SendAsync(request).ConfigureAwait(false);
            if(response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                T? obj = JsonSerializer.Deserialize<T>(resultString);
                return obj;
            }
            return null;
        }

        public async static Task<T> Post(string url, string body)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "application/json");
            //var content = new StringContent("{\r\n    \"name\": \"szisziakukas\",\r\n    \"email\": \"veress.martin33@gmail.com\",\r\n    \"password\": \"Abcd12345\",\r\n    \"password_confirmation\": \"Abcd12345\"\r\n}", null, "application/json");
            var content = new StringContent($"{body}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request).ConfigureAwait(false);
            if(response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                T obj = JsonSerializer.Deserialize<T>(resultString);
                return obj;
            }
            return null;
        }
    }
}
