using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Net5WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                CreateHostBuilder(args).Build().Run();
                Console.WriteLine("\nRestarting.........................\n");
                Thread.Sleep(1000); // give time to press a 2nd ctrl+c to quit program completely
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
