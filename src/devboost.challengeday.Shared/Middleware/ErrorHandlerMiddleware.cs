using devboost.challengeday.Shared.Response;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace devboost.challengeday.Shared.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = new ResponseResult();
                response.AddNotification(new Notification("erro interno", (ex.InnerException != null) ? ex.InnerException.Message : ex.Message));

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(
                    new
                    {
                        erros = response.Fails.Select(x => x.Message)
                    });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
