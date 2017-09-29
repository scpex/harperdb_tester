using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace harpertest 
{
    public static class HDBConfig
    {
        public static IConfigurationRoot Configuration { get; set; }
        private static string _HDBServer { get; set; }
        private static string _Authorization { get; set; }

        static HDBConfig()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("harperdb.json");

            Configuration = builder.Build();

            _HDBServer = Configuration["server"];
            _Authorization = Configuration["authorization"];
        }

        public static string HDBServer {
            get {
                return _HDBServer;
            }
            set {
                _HDBServer = value;
            }
        }

         public static string Authorization {
            get {
                return _Authorization;
            }
            set {
                _Authorization = value;
            }
        }
    }
}

  