using System.Net;
using AutoMapper;
using Seventh.Desafio.Api.ViewModel;

namespace Seventh.Desafio.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
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

            var responseModel = new ResponseViewModel(error?.Message ?? "An unknown error has occurred");

            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                switch (error)
                {
                    case AutoMapperMappingException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel = new ResponseViewModel("Error mapping types.")
                        {
                            Errors = new Dictionary<string, string>
                            {
                                {error.Source ?? string.Empty, error.Message}
                            }
                        };

                        break;

                    case FluentValidation.ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel = new ResponseViewModel("Validation failure.")
                        {
                            Errors = e.Errors.DistinctBy(e => e.PropertyName).ToDictionary(o => o.PropertyName, o => o.ErrorMessage)
                        };
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
            }

            await response.WriteAsync(responseModel.GetString());
        }
    }
}
