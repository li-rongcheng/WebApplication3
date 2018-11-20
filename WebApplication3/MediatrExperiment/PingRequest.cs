
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace WebApplication3.MediatrExperiment
{
    public class Ping : IRequest<string>
    { 
        public string SomeProp { get; set; }
    }
    
    public class PingHandler : IRequestHandler<Ping, string>
    {
        ILogger _logger;
        IValidator<Ping> _validator;

        public PingHandler(ILogger<PingHandler> logger, IValidator<Ping> validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public async Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            var results = await _validator.ValidateAsync(request);
            if(!results.IsValid)
            {
                foreach(var failure in results.Errors)
                {
                    _logger.LogError("_______ >>> Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }

                var failures = results.Errors.ToList();
                throw new ValidationException(failures, _logger);
            }

            _logger.LogDebug("Executing PingHandler.Handle() ...");
            return await Task.FromResult("Pong");
        }
    }
}