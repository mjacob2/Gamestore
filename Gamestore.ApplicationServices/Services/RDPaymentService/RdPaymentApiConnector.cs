using RestSharp;
using static Gamestore.ApplicationServices.Services.RDPaymentService.IRdPaymentApiConnector;

namespace Gamestore.ApplicationServices.Services.RDPaymentService;

public class RdPaymentApiConnector : IRdPaymentApiConnector, IDisposable
{
    private const string BaseUrl = "http://localhost:5000/";
    private readonly RestClient _restClient;

    public RdPaymentApiConnector()
    {
        _restClient = new RestClient(BaseUrl);
    }

    public async Task<bool> IBoxPaidWithSuccess(IboxPaymentRequest request)
    {
        var restRequest = new RestRequest("/api/payments/ibox", Method.Post);
        restRequest.AddJsonBody(request);
        var result = await _restClient.ExecuteAsync(restRequest);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> VisaPaidWithSuccess(VisaPaymentRequest request)
    {
        var restRequest = new RestRequest("/api/payments/visa", Method.Post);
        restRequest.AddJsonBody(request);
        var result = await _restClient.ExecuteAsync(restRequest);
        return result.IsSuccessStatusCode;
    }

    public void Dispose()
    {
        _restClient?.Dispose();
        GC.SuppressFinalize(this);
    }
}
