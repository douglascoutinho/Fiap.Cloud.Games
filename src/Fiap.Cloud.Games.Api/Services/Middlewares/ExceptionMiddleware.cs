using Fiap.Cloud.Games.Api.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Fiap.Cloud.Games.Api.Services.Middlewares
{
  /// <summary>
  /// Middleware para tratamento de exceções
  /// </summary>
  public class ExceptionMiddleware
  {

    readonly BaseLogger<ExceptionMiddleware> _logger;

    /// <summary>
    /// Capturar informações sobre requisições HTTP realizada na API
    /// </summary>
    private readonly RequestDelegate _requestDelegate;

    public ExceptionMiddleware(RequestDelegate requestDelegate, BaseLogger<ExceptionMiddleware> logger)
    {
      _requestDelegate = requestDelegate;
      _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpcontext)
    {
      try
      {
        // Executando a requisição normalmente
        await _requestDelegate(httpcontext);

        if (httpcontext.Response.StatusCode == (int)HttpStatusCode.Unauthorized ||
            httpcontext.Response.StatusCode == (int)HttpStatusCode.Forbidden)
        {
          await HandleSecurityStatusAsync(httpcontext);
        }
      }
      catch (ValidationException e)
      {
        await HandleExceptionAsync(httpcontext, e);
      }
      catch (ApplicationException e)
      {
        await HandleExceptionAsync(httpcontext, e);
      }
      catch (Exception e)
      {
        await HandleExceptionAsync(httpcontext, e);
      }
    }

    /// <summary>
    /// Método para o tratamento de exceções do Middleware
    /// </summary>
    public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
      var errorResponseModel = new ErrorResponseModel();
      errorResponseModel.Errors = new List<string>();

      switch (exception)
      {
        case ValidationException:
          httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
          foreach (var item in exception.Data.Values)
          {
            errorResponseModel.Errors.Add(item.ToString());
          }
          _logger.LogInformation("Validação de Regra ocorrido.");
          break;

        case ApplicationException:
          httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
          errorResponseModel.Errors.Add(exception.Message);
          _logger.LogError(exception.Message);
          break;

        default:
          httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          errorResponseModel.Errors.Add("Ocorreu um erro interno, entre em contato com o nosso suporte.");
          _logger.LogError("Ocorreu um erro interno, entre em contato com o nosso suporte.");
          break;
      }

      errorResponseModel.StatusCode = httpContext.Response.StatusCode;

      await WriteJsonResponseAsync(httpContext, errorResponseModel);
    }

    /// <summary>
    /// Método dedicado para tratar códigos de status 401 e 403 gerados pelo Authorize
    /// </summary>
    private async Task HandleSecurityStatusAsync(HttpContext httpContext)
    {
      if (httpContext.Response.HasStarted) return;

      var errorResponseModel = new ErrorResponseModel();
      errorResponseModel.Errors = new List<string>();
      errorResponseModel.StatusCode = httpContext.Response.StatusCode;

      if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
      {
        errorResponseModel.Errors.Add("Você precisa estar autenticado e enviar um token válido para acessar este recurso.");
        _logger.LogWarning("Acesso não autorizado tentado.");
      }
      else if (httpContext.Response.StatusCode == (int)HttpStatusCode.Forbidden)
      {
        errorResponseModel.Errors.Add("Seu perfil de usuário não tem permissão suficiente para acessar este recurso.");
        _logger.LogWarning("Acesso proibido tentado.");
      }

      await WriteJsonResponseAsync(httpContext, errorResponseModel);
    }

    /// <summary>
    /// Centraliza a escrita do JSON na resposta HTTP
    /// </summary>
    private async Task WriteJsonResponseAsync(HttpContext httpContext, ErrorResponseModel errorResponseModel)
    {
      httpContext.Response.ContentType = "application/json";
      await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorResponseModel));
    }
  }
}
