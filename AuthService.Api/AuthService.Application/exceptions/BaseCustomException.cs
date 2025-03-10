namespace AuthService.Application.exceptions;

public class BaseCustomException : Exception
{
    public int Code { get; }
    public override string StackTrace { get; }
    public BaseCustomException(string message, string stackTrace, int code) : base(message)
    {
        Code = code;
        StackTrace = stackTrace;
    }
}