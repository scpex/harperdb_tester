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
    public class  sql_tester
    {
        //[Fact]
        public async Task CreateSchemaAndTable()
        {
             HDBClient client = new HDBClient();
             string query = @"{ ""operation"":""create_schema"", ""schema"": ""sql"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);

              if(responseContent.Contains("created"))
              {
                  string tableQuery = @"{ ""operation"":""create_table"", ""schema"": ""sql"", ""table"":""dog"", ""hash_attribute"":""id"" }";
                  Console.Out.WriteLine("Request: " + query);
                  var tableResult = await client.PostAsync(HDBConfig.HDBServer, new StringContent(tableQuery, Encoding.UTF8, "application/json"));
                  String tableResponseContent = await tableResult.Content.ReadAsStringAsync();
                  Console.Out.WriteLine("ResponseJson: " + tableResponseContent);
              }else{
                  Console.Out.WriteLine("ResponseJson: The schema was created!!!");
              }
        }
        //[Fact]
        public async Task Insert_data()
        {
             HDBClient client = new HDBClient();
             string query = @"{ ""operation"":""sql"", ""sql"": ""INSERT INTO sql.dog (id, name) VALUES(1, 'Simon')"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);

        }
        //[Fact]
        public async Task Select_data()
        {
             HDBClient client = new HDBClient();
             string query = @"{ ""operation"":""sql"", ""sql"": ""select name from sql.dog where id = 1"" }";
             Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
        }
        //[Fact]
        public async Task Update_data()
        {
             HDBClient client = new HDBClient();
             string query = @"{ ""operation"":""sql"", ""sql"": ""update sql.dog set name = 'Hugo' where id = 1"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
        }
        //[Fact]
        public async Task Delete_data()
        {
             HDBClient client = new HDBClient();
             string query = @"{ ""operation"":""sql"", ""sql"": ""DELETE FROM sql.dog WHERE name = 'Hugo'"" }";
              Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
        }
        //[Fact]
        public async Task Select_data2()
        {
             HDBClient client = new HDBClient();
             string query = @"{ ""operation"":""sql"", ""sql"": ""select name from sql.dog"" }";
             Console.Out.WriteLine("Request: " + query);
              var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
              String responseContent = await result.Content.ReadAsStringAsync();
              dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
              Console.Out.WriteLine("ResponseJson: " + responseJson);
        }
    }
}