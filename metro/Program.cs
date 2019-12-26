using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using metro.Initialize;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace metro
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //KthShortest.Init(EntityFactory.metros);
            //var kshortest = new KthShortest();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
