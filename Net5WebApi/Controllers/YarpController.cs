using Microsoft.AspNetCore.Mvc;
using Microsoft.ReverseProxy.Abstractions;
using Microsoft.ReverseProxy.Service;
using Net5WebApi.Messages;
using Net5WebApi.YarpConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Net5WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YarpController : ControllerBase
    {
        InMemoryConfigProvider _inMemoryConfigProvider;

        public YarpController(IProxyConfigProvider proxyConfigProvider)
        {
            _inMemoryConfigProvider = (InMemoryConfigProvider) proxyConfigProvider;
        }

        // POST api/<YarpController>
        [HttpPost]
        public void Post([FromBody] Value value)
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
                        { "destination1", new Destination() { Address = $"{value.value}" } }
                    }
                }
            };

            _inMemoryConfigProvider.Update(routes, clusters);

            Console.WriteLine($"Yarp post called, value: {value.value}");
        }

        //// PUT api/<YarpController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<YarpController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
