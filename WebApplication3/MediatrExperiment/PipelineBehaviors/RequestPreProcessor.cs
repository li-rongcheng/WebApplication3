using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace WebApplication3.MediatrExperiment.PipelineBehaviors
{
    public class GenericRequestPreprocessor2<T> : IRequestPreProcessor<T>
    {
        readonly ILogger _logger;

        public GenericRequestPreprocessor2(ILogger<GenericRequestPreprocessor2<T>> logger)
        {
            _logger = logger;
        }

        public Task Process(T request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("~~2 GenericRequestPreprocessor2<> executed");
            return Task.CompletedTask;
        }
    }

    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        readonly ILogger _logger;

        public GenericRequestPreProcessor(ILogger<GenericRequestPreProcessor<TRequest>> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("~~1 GenericRequestPreProcessor<> executed");
            return Task.CompletedTask;
        }
    }

    /** don't do this:
     *  an exception "System.ArgumentException" will be thrown out in runtime
     */
    //public class PingPipelinePreProcess : IRequestPreProcessor<Ping>
    //{
    //    ILogger _logger;

    //    public PingPipelinePreProcess(ILogger<PingPipelinePreProcess> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public Task Process(Ping request, CancellationToken cancellationToken)
    //    {
    //        _logger.LogWarning($"{typeof(PingPipelinePreProcess).Name}.Process() called");
    //        return Task.CompletedTask;
    //    }
    //}
}