namespace CarApp.WebApp.Services.Abstracts;

public abstract class ClientServiceBase
{
    protected EndPoints EndPoints { get; }
    protected HttpClient HttpClient { get; }
    public ClientServiceBase(EndPoints EndPoints, IHttpClientFactory httpClientFactory)
    {
        this.EndPoints = EndPoints;
        HttpClient = httpClientFactory!.CreateClient("CarApp");
    }
}
