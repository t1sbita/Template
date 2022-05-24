using Template.Api.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace Template.Api.Filters
{
    /// <summary>
    /// ExceptionHandlerFilterAttribute
    /// </summary>
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {

        /// <summary>
        /// ExceptionHandlerFilterAttribute.OnException
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            if (context != null)
            {
                context.HttpContext.Response.ContentType = "application/problem+json";

                var businessException = context.Exception as BusinessException;
                if (businessException != null)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    if ((businessException?.Problem?.Erros?.Count ?? 0) > 0)
                    {
                        context.Result = new JsonResult(new
                        {
                            status = context.HttpContext.Response.StatusCode,
                            error = businessException.Problem.Erros.SelectMany(e => e.FieldErros)
                        });
                    }
                    else
                    {
                        context.Result = new JsonResult(new
                        {
                            status = context.HttpContext.Response.StatusCode,
                            error = businessException?.Message
                        });
                    }
                }
                else
                {
                    var authorizationException = context.Exception as AuthorizationException;
                    var persistenceException = context.Exception as PersistenceException;

                    if (authorizationException != null)
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }
                    else if (persistenceException != null)
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    }
                    else
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }

                    context.Result = new JsonResult(new
                    {
                        status = context.HttpContext.Response.StatusCode,
                        error = context.Exception.Message,
                        stackTrace = context.Exception.StackTrace
                    });
                }
            }
        }
    }
}
