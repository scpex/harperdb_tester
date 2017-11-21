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
    public class SQL_Test2
    {
        //[Fact]
        public async Task select_data_subdistrict()
        {
            HDBClient client = new HDBClient();

            string query = @"{""operation"":""sql"",""sql"":""select * from thailand.subdistrict""}";
            Console.Out.WriteLine("Request Body: " + query);

            var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));

            String responseContent = await result.Content.ReadAsStringAsync();

            dynamic responseJson = JsonConvert.DeserializeObject(responseContent);

            Console.Out.WriteLine("ResponseJson: " + responseJson);
            //Assert.Equal("Item not found!", responseJson.error);
        }
        public async Task sql(string sql)
        {
            HDBClient client = new HDBClient();
            sql="\""+sql+"\"";
            string query = @"{""operation"":""sql"",""sql"":"+sql+"}";
            Console.Out.WriteLine("Request Body: " + query);
            var result = await client.PostAsync(HDBConfig.HDBServer, new StringContent(query, Encoding.UTF8, "application/json"));
            String responseContent = await result.Content.ReadAsStringAsync();
            dynamic responseJson = JsonConvert.DeserializeObject(responseContent);
            Console.Out.WriteLine("ResponseJson: " + responseJson);
        }
        
    }
}
