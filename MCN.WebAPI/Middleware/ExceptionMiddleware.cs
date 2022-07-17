using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using MCN.Common.AttribParam;
using MCN.Common.Exceptions; 
using MCN.Infrastructure.Logging; 
using System; 
using System.Net;
using System.Threading.Tasks;

namespace MCN.WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private IRequestTrackerLogRepositoryBL _requestTrackerLogBL;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

            //_requestTrackerLogBL = requestTrackerLogBL;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            { 
                await _next.Invoke(httpContext);
            }
            catch (UserThrownBadRequest ex)
            {
                await HandleUserThrownBadRequestAsync(httpContext, ex.Dataobj, ex.swal);
            }
            catch (UserThrownException ex)
            {
                await HandleUserThrownExceptionAsync(httpContext, ex.Dataobj, ex.swal);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleUserThrownExceptionAsync(HttpContext context, object Data, SwallText swall)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 499;
            var json = JsonConvert.SerializeObject(new SwallResponseWrapper()
            {
                StatusCode = 499,
                SwallText = swall,
                Data = Data
            });
            return context.Response.WriteAsync(json);
        }

        private Task HandleUserThrownBadRequestAsync(HttpContext context, object Data, SwallText swall)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var json = JsonConvert.SerializeObject(new SwallResponseWrapper()
            {
                StatusCode = 400,
                SwallText = swall,
                Data = Data
            });
            return context.Response.WriteAsync(json);

        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            LockLoggingService.LockErrorLog(exception);
            var json = JsonConvert.SerializeObject(new SwallResponseWrapper()
            {
                StatusCode = 500,
                SwallText = new SwallText("error", "Internal Server Error Occurred!",
                "Internal Server Error Occurred. We are sorry for inconvinience."),
                Data = exception
            });
            return context.Response.WriteAsync(json);
        }
    }
}
