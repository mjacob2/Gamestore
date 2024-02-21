namespace Gamestore.DataAccess.Mongo.Exceptions;
public class UniquePropertyException : Exception
{
    public UniquePropertyException(string propertyName = "This property", string propertyValue = "")
        : base($"{propertyName} {propertyValue} is already taken. Please provide unique.")
    {
    }
}
