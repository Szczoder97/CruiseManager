using CruiseManager.Shared.Abstractions.Exceptions;

namespace CruiseManager.Shared.Infrastructure.Exceptions;

public interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception ex);
}