
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace WebApplication3.MediatrExperiment
{
    public class Ping : IRequest<string> { }
    
    public class PingHandler : IRequestHandler<Ping, string>
    {
        ILogger _logger;

        public PingHandler(ILogger<PingHandler> logger)
        {
            _logger = logger;
        }

        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Executing PingHandler.Handle() ...");
            return Task.FromResult("Pong");
        }
    }
}