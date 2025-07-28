namespace MyArticles.Models;

using System.Net;

// Members which use type parameter
public class Result<T>(T? value = default, bool success = true, string message = "", HttpStatusCode statusCode = HttpStatusCode.OK) : Result(success, message, statusCode)
{
    public T? Value { get; } = value;
    public static Result<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
                                => new(default, false, message, statusCode);
}

// Members which don't depend on the type parameter
public class Result(bool success = true, string message = "", HttpStatusCode statusCode = HttpStatusCode.OK)
{
    public bool IsSuccess { get; } = success;
    public string? Message { get; } = message;
    public HttpStatusCode Code { get; } = statusCode;
    public static Result Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
                            => new(false, message, statusCode);
    public bool IsFailed => !IsSuccess;
}