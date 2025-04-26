using System.Net;

namespace Domain.Commons;

/// <summary>
/// Representa o resultado de uma operação, contendo informações de sucesso/falha e dados retornados
/// </summary>
public class Result<T>
{
    public T? Data { get; private set; }

    public bool Success { get; private set; }

    public string Message { get; private set; }

    public HttpStatusCode StatusCode { get; private set; }

    public IList<string>? Errors { get; private set; }

    protected Result(T? data, bool success, string message, HttpStatusCode statusCode, IList<string>? errors = null)
    {
        Data = data;
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Errors = errors;
    }

    public static Result<T> Ok(T data, string message = "Operação realizada com sucesso")
    {
        return new Result<T>(data, true, message, HttpStatusCode.OK);
    }

    public static Result<T> Created(T data, string message = "Recurso criado com sucesso")
    {
        return new Result<T>(data, true, message, HttpStatusCode.Created);
    }

    public static Result<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        IList<string>? errors = null)
    {
        return new Result<T>(default, false, message, statusCode, errors);
    }

    public static Result<T> NotFound(string message = "Recurso não encontrado")
    {
        return new Result<T>(default, false, message, HttpStatusCode.NotFound);
    }

    public static Result<T> BadRequest(string message = "Requisição inválida", IList<string>? errors = null)
    {
        return new Result<T>(default, false, message, HttpStatusCode.BadRequest, errors);
    }

    public static Result<T> Unauthorized(string message = "Acesso não autorizado")
    {
        return new Result<T>(default, false, message, HttpStatusCode.Unauthorized);
    }

    public static Result<T> Forbidden(string message = "Acesso proibido")
    {
        return new Result<T>(default, false, message, HttpStatusCode.Forbidden);
    }

    public static Result<T> InternalServerError(string message = "Erro interno do servidor",
        IList<string>? errors = null)
    {
        return new Result<T>(default, false, message, HttpStatusCode.InternalServerError, errors);
    }
}

public class Result
{
    public bool Success { get; private set; }
    
    public string Message { get; private set; }
    
    public HttpStatusCode StatusCode { get; private set; }
    
    public IList<string>? Errors { get; private set; }

    protected Result(bool success, string message, HttpStatusCode statusCode, IList<string>? errors = null)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Errors = errors;
    }

    public static Result Ok(string message = "Operação realizada com sucesso")
    {
        return new Result(true, message, HttpStatusCode.OK);
    }

    public static Result Created(string message = "Recurso criado com sucesso")
    {
        return new Result(true, message, HttpStatusCode.Created);
    }

    public static Result Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        IList<string>? errors = null)
    {
        return new Result(false, message, statusCode, errors);
    }

    public static Result NotFound(string message = "Recurso não encontrado")
    {
        return new Result(false, message, HttpStatusCode.NotFound);
    }

    public static Result BadRequest(string message = "Requisição inválida", IList<string>? errors = null)
    {
        return new Result(false, message, HttpStatusCode.BadRequest, errors);
    }

    public static Result Unauthorized(string message = "Acesso não autorizado")
    {
        return new Result(false, message, HttpStatusCode.Unauthorized);
    }

    public static Result Forbidden(string message = "Acesso proibido")
    {
        return new Result(false, message, HttpStatusCode.Forbidden);
    }

    public static Result InternalServerError(string message = "Erro interno do servidor", IList<string>? errors = null)
    {
        return new Result(false, message, HttpStatusCode.InternalServerError, errors);
    }
}