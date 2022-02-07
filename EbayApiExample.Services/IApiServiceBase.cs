namespace EbayApiExample.Services;

public interface IApiServiceBase
{
    T GetResponseJson<T>(string endpoint);
    HttpResponseMessage CallApi(string endpoint);
}