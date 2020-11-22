using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ReverseProxy.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5WebApi.YarpConfigs
{
    public static class ConfigServiceExtension
    {
        public static void AddYarp(this IServiceCollection services)
        {
            var routes = new[]
            {
                new ProxyRoute()
                {
                    RouteId = "route1",
                    ClusterId = "cluster1",
                    Match =
                    {
                        Path = "{**catch-all}"
                    }
                }
            };

            var clusters = new[]
            {
                new Cluster()
                {
                    Id = "cluster1",
                    Destinations =
                    {
                        { "destination1", new Destination() { Address = "https://www.6park.com" } }
                    }
                }
            };

            services.AddReverseProxy()
                    .LoadFromMemory(routes, clusters);
        }

        public static void UseYarp(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });
        }
    }
}
