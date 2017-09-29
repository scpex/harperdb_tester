

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace harpertest {

    public class TestConnect {

        public async Task Connect()
        {
            var _client = new HttpClient();

            string url = "http://harperdbperf.westcentralus.cloudapp.azure.com:9925";
           // string auth = "Basic aGFycGVyZGI6TXljb3N0ZWNoMjM0IQ==";

            string requestUrl = string.Format(url);

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("authorization", HDBConfig.Authorization);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string query = @"{ ""operation"":""describe_all"" }";

            
            var response = await _client.PostAsync(requestUrl, new StringContent(query, Encoding.UTF8, "application/json"));

             String responseContent = await response.Content.ReadAsStringAsync();

             var responseJson = JsonConvert.DeserializeObject(responseContent);

             Console.Out.WriteLine("ResponseJson: " + responseJson);

        }
    }
}