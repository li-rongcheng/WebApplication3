using Autofac.Extensions.DependencyInjection;
using GraphQLWorkerService1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWorkerService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) // need to install package: Autofac.Extensions.DependencyInjection
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddEntityFrameworkInMemoryDatabase()
                            .AddDbContext<MovieContext>(context => { context.UseInMemoryDatabase("MovieDb"); });

                    services.AddHostedService<Worker>();
                });
    }
}
