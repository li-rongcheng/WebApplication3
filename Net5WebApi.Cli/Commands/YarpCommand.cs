using Net5WebApi.Messages;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Net5WebApi.Cli.Commands
{
    [Headers("User-Agent: .NET Foundation Repository Reporter")]    // must have, otherwise will return 403 forbidden
    interface IYarpApi
    {
        [Post("/api/yarp")]
        Task DoAsync([Body] Value value);
    }

    class YarpCommand
    {
        public async Task Test(string address)
        {
            try
            {
                var httpClient = new HttpClient(
                    new HttpClientHandler { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true }
                )
                { BaseAddress = new Uri("https://localhost:5001") };

                var yarp = RestService.For<IYarpApi>(httpClient);
                await yarp.DoAsync(new Value { value = address });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
