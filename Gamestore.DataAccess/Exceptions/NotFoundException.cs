namespace Gamestore.DataAccess.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message = "Item does not exist")
        : base(message)
    {
    }
}
