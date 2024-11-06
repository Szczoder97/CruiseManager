using System.Collections.Concurrent;
using System.Net;
using CruiseManager.Shared.Abstractions.Exceptions;
using Humanizer;

namespace CruiseManager.Shared.Infrastructure.Exceptions;

public class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();
    public ExceptionResponse Map(Exception ex)
        => ex switch
        {
            CustomException cex => new ExceptionResponse(new ErrorsResponse(new Error(GetErrorCode(cex), cex.Message)),
                HttpStatusCode.BadRequest),
            _ => new ExceptionResponse(new ErrorsResponse(new Error("error", "There was an error.")),
                HttpStatusCode.InternalServerError)
        };

    private record Error(string Code, string Message);

    private record ErrorsResponse(params Error[] Errors);

    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        return Codes.GetOrAdd(type, type.Name.Underscore().Replace("_exception", string.Empty));
    }
}