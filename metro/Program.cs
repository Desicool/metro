using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using metro.Entities;
using metro.Initialize;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace metro
{
    public class Program
    {
        public static Dictionary<KeyValuePair<string, string>, List<Route>> routeDic = new Dictionary<KeyValuePair<string, string>, List<Route>>();

        public static void Main(string[] args)
        {
            LoadRoute();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void LoadRoute()
        {
            string filePath = @"..\..\transfer.json";
            using (FileStream fsRead = new FileStream(filePath, FileMode.Open))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                string myStr = System.Text.Encoding.UTF8.GetString(heByte);
                routeDic = JsonConvert.DeserializeObject<Dictionary<KeyValuePair<string, string>, List<Route>>>(myStr);
            }
        }
    }
}
