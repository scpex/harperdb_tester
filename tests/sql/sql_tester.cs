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
    public class SQL_Test
    {
        public async Task create_schema_northnwd()
        {
            HDBClient client = new HDBClient();

            string query = @"{""operation"":""create_schema"",""schema"":""northnwd""}";
            Console.Out.WriteLine("Request Body: " + query);

            var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

            String responseContent = await result.Content.ReadAsStringAsync();

            dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

            Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson.error);
        }
        public async Task create_table_customers()
        {
            HDBClient client = new HDBClient();

            string query = @"{""operation"":""create_table"",""schema"":""northnwd"",""table"":""customers"",""hash_attribute"": ""id""}";
            Console.Out.WriteLine("Request Body: " + query);

            var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

            String responseContent = await result.Content.ReadAsStringAsync();

            dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

            Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson);
        }
        //[Fact]
        public async Task import_csvdata_customers()
        {
            HDBClient client = new HDBClient();

            string query = @"{""operation"":""csv_file_load"",""schema"":""northnwd"",""table"":""customers"",""file_path"": ""/home/code/databases/Customers.csv""}";
            Console.Out.WriteLine("Request Body: " + query);

            var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

            String responseContent = await result.Content.ReadAsStringAsync();

            dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

            Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson.error);
        }
        //[Fact]
        public async Task select_data_customers()
        {
            HDBClient client = new HDBClient();

            string query = @"{""operation"":""sql"",""sql"":""select * from northnwd.customers""}";
            Console.Out.WriteLine("Request Body: " + query);

            var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

            String responseContent = await result.Content.ReadAsStringAsync();

            dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

            Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson.error);
        }
        public async Task drop_table_customers()
        {
            HDBClient client = new HDBClient();

            string query = @"{""operation"":""drop_table"",""schema"":""northnwd"",""table"":""customers""}";
            Console.Out.WriteLine("Request Body: " + query);

            var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

            String responseContent = await result.Content.ReadAsStringAsync();

            dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

            Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson.error);
        }
        
    }
}
