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
    public class TestJsonDocs
    {
        //[Fact]
        public async Task CreateSchemaAndTable()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""create_schema"", ""schema"": ""jsonTests"" }";

              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson);

              if(responseContent.Contains("created"))
              {
                  string tableQuery = @"{ ""operation"":""create_table"", ""schema"": ""jsonTests"", ""table"":""basic"", ""hash_attribute"":""id"" }";

                  var tableResult = await client.PostAsync(HDBConfig.HDBServer, new StringContent(tableQuery, Encoding.UTF8, "application/json"));

                  String tableResponseContent = await tableResult.Content.ReadAsStringAsync();

                  Console.Out.WriteLine("ResponseJson: " + tableResponseContent);
              }
        }
     
        //[Fact]
        public async Task DropSchemaAndTable()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""drop_schema"", ""schema"": ""jsonTests"" }";

              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson);

        }

        //[Fact]
        public async Task AddSimpleJson()
        {
            CreateSchemaAndTable().Wait();

            var dir = Directory.GetCurrentDirectory();

            dynamic json = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(dir + Path.DirectorySeparatorChar +  @"basicjson.json"));

            HDBClient client = new HDBClient();

            var response = await client.PostAsync(HDBConfig.HDBServer, new StringContent(json.ToString(), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            Console.Out.WriteLine(content);

            DropSchemaAndTable().Wait();

           // Assert.Equal("Test response", content);
           // Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        }
    }
}
