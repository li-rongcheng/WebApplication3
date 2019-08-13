
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplication3.MediatrExperiment.PipelineBehaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger _logger;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<RequestValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogTrace("RequestValidationBehavior.Handle() called");

           var context = new ValidationContext(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            // if (failures.Count != 0)
            // {
            //     throw new ValidationException(failures, _logger);
            // }

            return await next();
        }
    }

    public class MyValidationException : Exception
    {
        private readonly ILogger _logger;
        public IDictionary<string, string[]> Failures { get; }

        public MyValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public MyValidationException(List<ValidationFailure> failures, ILogger logger)
            : this()
        {
            this._logger = logger;
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
                foreach(var error in propertyFailures)
                    _logger.LogError($"{propertyName} validation failed: {error}");
            }
        }
    }

    /** [MCN] This is a global exception filter */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly ILogger _logger;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError("$--------- OnException() called ---------$");

            if (context.Exception is MyValidationException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new JsonResult(((MyValidationException)context.Exception).Failures);

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            // if (context.Exception is NotFoundException)
            // {
            //     code = HttpStatusCode.NotFound;
            // }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}