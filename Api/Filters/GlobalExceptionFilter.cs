using System.Net;
using Domain.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, context.Exception.Message);

        var result = Result.InternalServerError(
            _env.IsDevelopment()
                ? $"Erro interno: {context.Exception.Message}"
                : "Ocorreu um erro interno no servidor.");

        if (_env.IsDevelopment())
        {
            // Adiciona mais detalhes na resposta quando em ambiente de desenvolvimento
            var errorsList = new List<string>
            {
                $"StackTrace: {context.Exception.StackTrace}",
                $"Source: {context.Exception.Source}"
            };

            if (context.Exception.InnerException != null)
            {
                errorsList.Add($"InnerException: {context.Exception.InnerException.Message}");
            }

            result = Result.InternalServerError(
                $"Erro interno: {context.Exception.Message}",
                errorsList);
        }

        context.Result = new ObjectResult(result)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError
        };

        context.ExceptionHandled = true;
    }
}