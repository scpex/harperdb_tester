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
    public class TestSchema
    {
        //[Fact]
        public async Task CreateSchemaAndTable()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""create_schema"", ""schema"": ""root"" }";

              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson);

              if(responseContent.Contains("created"))
              {
                  string tableQuery = @"{ ""operation"":""create_table"", ""schema"": ""root"", ""table"":""dog"", ""hash_attribute"":""id"" }";

                  var tableResult = await client.PostAsync(HDBConfig.HDBServer, new StringContent(tableQuery, Encoding.UTF8, "application/json"));

                  String tableResponseContent = await tableResult.Content.ReadAsStringAsync();

                  Console.Out.WriteLine("ResponseJson: " + tableResponseContent);
              }
        }
     
        //[Fact]
        public async Task DropSchemaAndTable()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""drop_schema"", ""schema"": ""root"" }";

              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson.error);
            Assert.Equal("Item not found!", responseJson.error);
        }
    }
}
