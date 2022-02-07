using AutoMapper;
using EbayApiExample.Models;
using Microsoft.Extensions.Configuration;

namespace EbayApiExample.Services;

public class InventoryService : IInventoryService
{
    private readonly IEbayApiService _ebayApiService;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public InventoryService(IEbayApiService ebayApiService, IConfiguration configuration, IMapper mapper)
    {
        _ebayApiService = ebayApiService;
        _configuration = configuration;
        _mapper = mapper;
    }

    public IEnumerable<ProductDto> GetProductDtos()
    {
        var inventoryItems = _ebayApiService.GetResponseJson<EbayResponseDto>(_configuration["EbayEndpointGetAll"]).inventoryItems;
        
        return _mapper.Map<IEnumerable<ProductDto>>(inventoryItems);
    }
}

