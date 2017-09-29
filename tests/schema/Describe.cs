using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Xunit;

namespace harpertest 
{
    public class Describe
    {
        //[Fact]
        public async Task Describe_all()
        {

            HDBClient client = new HDBClient();

            // Dictionary<string, string> jsonBody = new Dictionary<string, string>();
            // jsonBody.Add("operation", @"");
            // jsonBody.Add("sql", @"{select * from mycos.employees where id = '69c185dc-2392-45ab-b758-f7c51d1f3338'}");
            string query = @"{ ""operation"":""describe_all"" }";
            Console.Out.WriteLine("Request: "+ query);
            var response = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query,Encoding.UTF8,"application/json"));

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            dynamic schema = JsonConvert.DeserializeObject(content);
            Console.Out.WriteLine("Response: " + schema);
          //  Assert.True(schema.)
            //Assert.NotNull(content);

           // Assert.False(content.Contains("Invalid"));
           // Assert.Equal("Test response", content);
           // Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        }
        //[Fact]
        public async Task Describe_schema()
        {

            HDBClient client = new HDBClient();

            // Dictionary<string, string> jsonBody = new Dictionary<string, string>();
            // jsonBody.Add("operation", @"");
            // jsonBody.Add("sql", @"{select * from mycos.employees where id = '69c185dc-2392-45ab-b758-f7c51d1f3338'}");
            string query = @"{ ""operation"":""describe_schema"",""schema"":""northnwd"" }";
            Console.Out.WriteLine("Request: "+ query);
            var response = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query,Encoding.UTF8,"application/json"));

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            dynamic schema = JsonConvert.DeserializeObject(content);
            Console.Out.WriteLine("Response: " + schema);
          // Assert.True(schema.)
            //Assert.NotNull(content);

           // Assert.False(content.Contains("Invalid"));
           // Assert.Equal("Test response", content);
           // Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        }
    }
}
