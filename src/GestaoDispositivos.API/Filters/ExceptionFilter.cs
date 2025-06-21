using GestaoDispositivos.Communication.Responses;
using GestaoDispositivos.Exception;
using GestaoDispositivos.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestaoDispositivos.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is GestaoDispositivosException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnkowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var exception = (GestaoDispositivosException)context.Exception;
        var errorResponse = new ResponseError(exception.GetErrors());

        context.HttpContext.Response.StatusCode = exception.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnkowError(ExceptionContext context)
    {
        var errorResponse = new ResponseError(ResourceErrorMessages.Unknow_Error);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}