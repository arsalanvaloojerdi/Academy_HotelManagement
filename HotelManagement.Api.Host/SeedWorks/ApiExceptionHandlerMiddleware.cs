using HotelManagement.Application.Interfaces.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HotelManagement.Api.Host.SeedWorks
{
    public class ApiExceptionHandlerMiddleware
    {
        private readonly ILogger<ApiExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ApiExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<ApiExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException exception)
            {
                await ConfigureResponse(context, HttpStatusCode.BadRequest, exception.Message);
            }
            catch (Exception)
            {
                await ConfigureResponse(context, HttpStatusCode.InternalServerError, ApiMessages.Failure);
            }
        }

        #region PrivateMethods

        private static async Task ConfigureResponse(HttpContext context, HttpStatusCode statusCode, string message = null)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var responseModel = new ApiResponseModel<object>
            {
                ErrorInfo = new ApiResponseModelError
                {
                    Code = (int)statusCode,
                    Details = message
                }
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }

    #endregion
}