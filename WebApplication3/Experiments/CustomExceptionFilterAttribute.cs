
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;

namespace WebApplication3.Experiments
{
    /// <summary>
    /// from: "I:\rp\git\CoreCmdPlayground\CoreCmdPlayground\Commands\MediatR\PipelineBehaviors\RequestValidationBehavior.cs"
    /// </summary>
    public class MyValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }
    }

    /** [MCN] This is a global exception filter */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine("$--------- OnException() called ---------$");

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