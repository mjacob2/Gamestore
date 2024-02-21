namespace Gamestore.DataAccess.Exceptions;
public class NoUnitsInStockException : Exception
{
    public NoUnitsInStockException(string message = "No items in stock!")
        : base(message)
    {
    }
}
