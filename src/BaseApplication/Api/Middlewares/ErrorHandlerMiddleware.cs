using Application.Exceptions;
using Domain.DataTransferObjects.Collection;
using Persistence.Exceptions;
using System.Net;
using System.Text.Json;

namespace Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new CollectionResult<string>(true, Contract.Resources.Api.ApiResource.UnkownError_Happened);

                switch (error)
                {
                    case PersistenceException e:
                        // custom persist error for filetable
                        response.StatusCode = (int)HttpStatusCode.OK;
                        responseModel = new CollectionResult<string>(true, e.Errors);
                        break;
                    case ValidationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.OK;
                        responseModel = new CollectionResult<string>(true, e.Errors);
                        break;
                    case KeyNotFoundException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.OK;
                        responseModel = new CollectionResult<string>(false, Contract.Resources.Api.ApiResource.Not_Found);
                        break;
                    case UnauthorizedAccessException:
                        response.StatusCode = (int)HttpStatusCode.OK;
                        responseModel = new CollectionResult<string>(false, Contract.Resources.Api.ApiResource.UnAuthorize_Access);
                        break;
                    default:
                        // unhandled error
                        _logger.LogError(error, error?.Message);
                        response.StatusCode = (int)HttpStatusCode.OK;
                        break;
                }

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var result = JsonSerializer.Serialize(responseModel, serializeOptions);
                await response.WriteAsync(result);
            }
        }
    }
}
