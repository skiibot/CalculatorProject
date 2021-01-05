using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class CalculatorWebVersion 
    {
        private static HttpClient ApiClient = new HttpClient();

        public CalculatorWebVersion() 
        {
            ApiClient.BaseAddress = new Uri("https://localhost:44370/api/values/");

        }
        public async Task<int> Add (int start, int amount)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"add/{start}/{amount}");
            var response = await ApiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }

        public async Task<int> Divide(int start, int by)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"divide/{start}/{by}");
            var response = await ApiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }

        public async Task<int> Multiply(int start, int by)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"multiply/{start}/{by}");
            var response = await ApiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }

        public async Task<int> Subtract(int start, int amount)
        {
            int result = 0;
            var request = new HttpRequestMessage(HttpMethod.Get, $"subtract/{start}/{amount}");
            var response = await ApiClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultString = await response.Content.ReadAsStringAsync();
            result = int.Parse(resultString);
            return result;
        }
    }
}
