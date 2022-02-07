using Microsoft.Extensions.Configuration;

namespace EbayApiExample.Services;

public class EbayApiService : ApiServiceBase, IEbayApiService
{
    private readonly IConfiguration _configuration;

    public EbayApiService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public override HttpResponseMessage CallApi(string endpoint)
    {
        var client = new HttpClient();
        AddHeaders(client);
        return client.GetAsync(endpoint).Result;
    }

    private void AddHeaders(HttpClient client)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_configuration["Token"]}");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
    }
}