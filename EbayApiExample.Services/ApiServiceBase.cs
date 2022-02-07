using Newtonsoft.Json;

namespace EbayApiExample.Services;

public abstract class ApiServiceBase : IApiServiceBase
{
    public T GetResponseJson<T>(string endpoint)
    {
        var result = CallApi(endpoint).Content.ReadAsStringAsync();
        return DeserializeResponse<T>(result.Result);
    }

    private static T DeserializeResponse<T>(string result)
    {
        return JsonConvert.DeserializeObject<T>(result);
    }
    public abstract HttpResponseMessage CallApi(string endpoint);

}