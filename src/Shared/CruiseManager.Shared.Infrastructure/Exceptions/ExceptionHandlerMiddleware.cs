using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CruiseManager.Shared.Infrastructure.Exceptions;

public class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;
    private readonly IExceptionCompositionRoot _exceptionCompositionRoot;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> _logger,
        IExceptionCompositionRoot exceptionCompositionRoot)
    {
        this._logger = _logger;
        _exceptionCompositionRoot = exceptionCompositionRoot;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandlerExceptionAsync(context, ex);
        }
    }

    private async Task HandlerExceptionAsync(HttpContext context, Exception ex)
    {
        var errorReposne = _exceptionCompositionRoot.Map(ex);
        context.Response.StatusCode = (int)(errorReposne?.StatusCode ?? HttpStatusCode.InternalServerError);
        var response = errorReposne?.Response;
        if (response is null)
        {
            return;
        }

        await context.Response.WriteAsJsonAsync(response);
    }
}