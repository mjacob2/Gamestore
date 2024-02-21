namespace Gamestore.ApplicationServices.Services.RDPaymentService;
public interface IRdPaymentApiConnector
{
    Task<bool> IBoxPaidWithSuccess(IboxPaymentRequest request);

    Task<bool> VisaPaidWithSuccess(VisaPaymentRequest request);

    public class IboxPaymentRequest
    {
        public decimal TransactionAmount { get; set; }

        public string AccountNumber { get; set; }

        public string InvoiceNumber { get; set; }
    }

    public class VisaPaymentRequest
    {
        public decimal TransactionAmount { get; set; }

        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int Cvv { get; set; }

        public int ExpirationYear { get; set; }
    }
}
