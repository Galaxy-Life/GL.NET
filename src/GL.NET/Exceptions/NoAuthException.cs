namespace GL.NET.Exceptions;

public class NoAuthException : GLException
{
    public override string Message => "You are currently not authorized! Please make an authorized client by providing a ClientId and a ClientSecret for this endpoint.";
}
