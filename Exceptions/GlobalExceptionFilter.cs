using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Twitter.Exceptions
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger logger;
        
        public GlobalExceptionFilter(ILogger logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var StatusCode = GetStatusCode(context);

            logger.LogError(context.Exception, "Unhandled exception");

            var response = new
            {
                Error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = StatusCode
            };
                
            context.ExceptionHandled = true;
        }

        private int GetStatusCode(ExceptionContext context) 
        {
            if (context.Exception is NotFoundException)
                return StatusCodes.Status404NotFound;

            else if (context.Exception is UnauthorizedAccessException)
                return StatusCodes.Status403Forbidden;

            else if (context.Exception is ValidationException)
                return StatusCodes.Status400BadRequest;

            else
                return StatusCodes.Status500InternalServerError;
        }
    }
}
