
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace WebApplication3.MediatrExperiment
{
    public class Ping2 : INotification {}

    public class Ping2Handler : INotificationHandler<Ping2>
    {
        ILogger _logger;

        public Ping2Handler(ILogger<Ping2Handler> logger)
        {
            _logger = logger;
        }

        public Task Handle(Ping2 notification, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Executing Ping2Handler.Handle() ...");
            return Task.CompletedTask;
        }
    }
}