namespace Articles;
// Members which all use T

using System.Net;

public class Result<T>(bool success = true, string message = "", T? value = default, HttpStatusCode statusCode = HttpStatusCode.OK) : Result(success, message, statusCode)
{
    public T? Value { get; } = value;
    public static Result<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
                                => new(false, message, default, statusCode);
}

// Members which don't depend on the type parameter

public class Result(bool success = true, string message = "", HttpStatusCode statusCode = HttpStatusCode.OK)
{
    private bool IsSuccess { get; } = success;
    private string? Message { get; } = message;
    public bool IsFailed => !IsSuccess;
    protected HttpStatusCode code { get; } = statusCode;
    public static Result Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
                            => new(false, message, statusCode);
}