using EbayApiExample.Models;
using EbayApiExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace EbayApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            return _inventoryService.GetProductDtos();
        }
    }
}