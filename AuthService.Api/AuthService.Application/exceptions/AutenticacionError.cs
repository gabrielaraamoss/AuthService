namespace AuthService.Application.exceptions;

public class AutenticacionError : BaseCustomException
{
    public int Code { get; }
    public AutenticacionError(string message)
        : base(message, "AutenticacionError", 404)
    {
    }
}