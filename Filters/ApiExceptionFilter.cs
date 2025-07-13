using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.CompilerServices;

namespace APICatalogo.Filters;

public class ApiExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ApiExceptionFilter> _logger;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unexpected exception occurred");
        context.Result = new ObjectResult("Failed to process request")
        {
            StatusCode = StatusCodes.Status500InternalServerError,
        };
    }
}
