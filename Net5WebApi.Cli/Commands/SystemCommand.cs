using CoreCmd.Attributes;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Net5WebApi.Cli.Commands
{
    interface IWeatherApi
    {
        [Post("/api/system/reset")]
        Task Reset();
    }

    [Alias("sys")]
    class SystemCommand
    {
        public async Task Reset()
        {
            try
            {
                var httpClient = new HttpClient(
                    new HttpClientHandler { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true }
                )
                { BaseAddress = new Uri("https://localhost:5001") };

                await RestService.For<IWeatherApi>(httpClient).Reset();
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
