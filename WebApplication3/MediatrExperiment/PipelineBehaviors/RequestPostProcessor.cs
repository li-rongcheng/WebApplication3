using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace WebApplication3.MediatrExperiment.PipelineBehaviors
{
    public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        readonly ILogger _logger;

        public GenericRequestPostProcessor(ILogger<GenericRequestPostProcessor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, TResponse response)
        {
            _logger.LogInformation("+++ GenericRequestPostProcessor<> executed");
            return Task.CompletedTask;
        }
    }
}