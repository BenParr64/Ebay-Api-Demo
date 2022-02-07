using AutoMapper;
using EbayApiExample.Models;

namespace EbayApiExample.Services.Profiles;

public class InventoryItemProfile : Profile
{
    public InventoryItemProfile()
    {
        CreateMap<InventoryItem, ProductDto>()
            .ForPath(dest => dest.Quantity,
                opt => opt.MapFrom(src => src.availability.shipToLocationAvailability.quantity))
            .ForPath(dest => dest.Title, opt => opt.MapFrom(src => src.product.title))
            .ForPath(dest => dest.Description, opt => opt.MapFrom(src => src.product.description))
            ;
    }
}