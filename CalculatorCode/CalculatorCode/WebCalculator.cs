using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCode
{
    class WebCalculator : IWebCalculator
    {
        private static HttpClient _httpClient = new HttpClient();
        public  WebCalculator()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:57985/"); //base address
            _httpClient.Timeout = new TimeSpan(0, 0, 30); // 30s timeout limit
        }

        public async Task<string> GetResource(int service, int a, int b)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, $"api/{service}/{a}/{b}");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
