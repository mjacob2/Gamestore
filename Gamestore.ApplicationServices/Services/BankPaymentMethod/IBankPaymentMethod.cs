using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Services.BankPaymentMethod;
public interface IBankPaymentMethod
{
    Stream GenerateInvoice(Order order);
}
