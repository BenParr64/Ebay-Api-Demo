using EbayApiExample.Models;

namespace EbayApiExample.Services;

public interface IInventoryService
{
    IEnumerable<ProductDto> GetProductDtos();
}