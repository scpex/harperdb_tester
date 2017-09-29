using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace harpertest 

{
    public class HDBClient : HttpClient, IDisposable 
    {
        static string fullUrl = HDBConfig.HDBServer;


        public HDBClient()
        {
         

            //string requestUrl = string.Format(fullUrl);

            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Add("authorization", HDBConfig.Authorization);
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
