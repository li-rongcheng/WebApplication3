using CoreCmd.CommandExecution;
using System;
using System.Threading.Tasks;

namespace Net5WebApi.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new AssemblyCommandExecutor().ExecuteAsync(args, services => { });
        }
    }
}
