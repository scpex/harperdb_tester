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
    public class CRUD_test
    {
        //[Fact]
        public async Task Insert_test()
        {
            var dir = Directory.GetCurrentDirectory();
            dynamic query = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(dir + Path.DirectorySeparatorChar +  @"/tests/schema/dog.json"));

              HDBClient client = new HDBClient();
              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query.ToString(), Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson.error);
              Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Update_test()
        {
            var dir = Directory.GetCurrentDirectory();
            dynamic query = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(dir + Path.DirectorySeparatorChar +  @"/tests/schema/dog_update.json"));

             HDBClient client = new HDBClient();
              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query.ToString(), Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson.error);
              Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Search_test()
        {
            var dir = Directory.GetCurrentDirectory();
            dynamic query = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(dir + Path.DirectorySeparatorChar +  @"/tests/schema/search_dog.json"));
             HDBClient client = new HDBClient();
              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query.ToString(), Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson.error);
              Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Delete_test()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""delete"", ""table"":""dog"",""schema"": ""dev"",""hash_value"":[""3""] }";
              Console.Out.WriteLine("Request Body: " + query);

              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

              String responseContent = await result.Content.ReadAsStringAsync();

              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

              Console.Out.WriteLine("ResponseJson: " + responseJson.error);
              Assert.Equal("Item not found!", responseJson.error);
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
