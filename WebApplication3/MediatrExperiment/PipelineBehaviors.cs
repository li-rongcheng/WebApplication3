
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace WebApplication3.MediatrExperiment
{
    public class LoggingBehavior2<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    {
        private readonly ILogger _logger;
        public LoggingBehavior2(ILogger<LoggingBehavior2<TRequest,TResponse>> logger)
        {
            _logger=logger;
        }
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogCritical("LoggingBehavior2 --- start");
            var response = await next();
            _logger.LogCritical("LoggingBehavior2 --- finish");
            return response;
        }
    }

    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    {
        private readonly ILogger _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest,TResponse>> logger)
        {
            _logger=logger;
        }
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogWarning("LoggingBehavior ... begin");
            var response = await next();
            _logger.LogWarning("LoggingBehavior ... end");
            return response;
        }
    }

    public class PingPipelineBehavior : IPipelineBehavior<Ping, string>
    {
        private readonly ILogger _logger;
        public PingPipelineBehavior(ILogger<PingPipelineBehavior> logger)
        {
            _logger = logger;
        }

        public async Task<string> Handle(Ping request, CancellationToken cancellationToken, RequestHandlerDelegate<string> next)
        {
            _logger.LogError($">>> Start to handle {typeof(PingPipelineBehavior).Name}");
            var response = await next();
            _logger.LogError($"<<< End of Handling {typeof(PingPipelineBehavior).Name}");
            return response;
        }
    }
}