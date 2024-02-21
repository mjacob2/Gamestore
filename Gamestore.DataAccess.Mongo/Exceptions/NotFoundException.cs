namespace Gamestore.DataAccess.Mongo.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message = "Item does not exist")
        : base(message)
    {
    }
}
