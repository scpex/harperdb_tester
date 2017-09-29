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
    public class The_Tester
    {
        //[Fact]
        public async Task CreateSchemaAndTable()
        {
             HDBClient client = new HDBClient();
             string query = @"{ ""operation"":""create_schema"", ""schema"": ""dev"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);

              if(responseContent.Contains("created"))
              {
                  string tableQuery = @"{ ""operation"":""create_table"", ""schema"": ""dev"", ""table"":""dog"", ""hash_attribute"":""id"" }";
                  Console.Out.WriteLine("Request: " + query);
                  var tableResult = await client.PostAsync(HDBConfig.HDBServer, new StringContent(tableQuery, Encoding.UTF8, "application/json"));
                  String tableResponseContent = await tableResult.Content.ReadAsStringAsync();
                  Console.Out.WriteLine("ResponseJson: " + tableResponseContent);
              }else if(responseContent.Contains("Schema dev already exists"))
              {
                  string tableQuery = @"{ ""operation"":""create_table"", ""schema"": ""root"", ""table"":""dog"", ""hash_attribute"":""id"" }";
                  Console.Out.WriteLine("Request: " + query);
                  var tableResult = await client.PostAsync(HDBConfig.HDBServer, new StringContent(tableQuery, Encoding.UTF8, "application/json"));
                  String tableResponseContent = await tableResult.Content.ReadAsStringAsync();
                  Console.Out.WriteLine("ResponseJson: " + tableResponseContent);
              }else{
                  Console.Out.WriteLine("ResponseJson: The schema was created!!!");
              }
        }
        //[Fact]
        public async Task Insert_Data()
        {
            var dir = Directory.GetCurrentDirectory();
            dynamic query = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(dir + Path.DirectorySeparatorChar +  @"/tests/schema/dog.json"));
              HDBClient client = new HDBClient();
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query.ToString(), Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
              //Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Describe_table()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""describe_table"", ""table"":""dog"",""schema"": ""root"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("Response: " + responseJson);
              //Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Update_Data()
        {
            var dir = Directory.GetCurrentDirectory();
            dynamic query = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(dir + Path.DirectorySeparatorChar +  @"/tests/schema/dog_update.json"));
             HDBClient client = new HDBClient();
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query.ToString(), Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
              //Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Search_Data()
        {
            var dir = Directory.GetCurrentDirectory();
            dynamic query = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(dir + Path.DirectorySeparatorChar +  @"/tests/schema/sub_district.json"));
             HDBClient client = new HDBClient();
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query.ToString(), Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
            //  Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Delete_Data()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""delete"", ""table"":""dog"",""schema"": ""dev"",""hash_value"":[""3""] }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
              //Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task DropTable()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""drop_table"", ""schema"": ""root"", ""table"": ""dog"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task DropSchema()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""drop_schema"", ""schema"": ""root"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task Describe_table2()
        {
             HDBClient client = new HDBClient();

             string query = @"{ ""operation"":""describe_table"", ""table"":""dog"",""schema"": ""root"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("Response: " + responseJson);
              //Assert.Equal("Item not found!", responseJson.error);
        }
    }
}