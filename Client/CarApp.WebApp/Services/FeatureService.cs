using CarApp.WebApp.Services.Abstracts;

namespace CarApp.WebApp.Services;

public class FeatureService : ClientServiceBase
{
    public FeatureService(EndPoints EndPoints, IHttpClientFactory httpClientFactory) : base(EndPoints, httpClientFactory)
    {
    }

    public async Task<IEnumerable<WebApi.Models.Feature>>GetFeauturesAsync()
    {
        string? url = EndPoints.Feature.GetFeature;
        HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
        var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<WebApi.Models.Feature>>();
        return response;
    }
}
