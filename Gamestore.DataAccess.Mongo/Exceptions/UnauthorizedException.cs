namespace Gamestore.DataAccess.Mongo.Exceptions;
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message)
        : base(message)
    {
    }
}
