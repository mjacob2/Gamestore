namespace Gamestore.DataAccess.Mongo.Exceptions;
public class PaymentRejectedException : Exception
{
    public PaymentRejectedException(string paymentMethod)
    : base($"{paymentMethod} payment was rejected! Contact payment provider!")
    {
    }
}
