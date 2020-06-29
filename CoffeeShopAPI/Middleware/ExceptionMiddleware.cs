using CoffeeShopAPI.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeShopAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _enviroment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment enviroment)
        {
            _next = next;
            _logger = logger;
            _enviroment = enviroment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var responce = _enviroment.IsDevelopment()
                ? new ApiCustomException((int)HttpStatusCode.InternalServerError, ex.Message,
                ex.StackTrace.ToString())
                : new ApiResponce((int)HttpStatusCode.InternalServerError);

                var json = JsonSerializer.Serialize(responce);

                await context.Response.WriteAsync(json);

            }

        }
    }
}
