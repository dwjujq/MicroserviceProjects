using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Inventory.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Inventory")]
    [AllowAnonymous]
    public class OrderController : BaseApiController
    {
        readonly IInventoryServices _inventoryServices;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IInventoryServices inventoryServices, ILogger<OrderController> logger)
        {
            _inventoryServices = inventoryServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InventoryDto inventoryDto)
        {
            var result = await _inventoryServices.Create(inventoryDto);
            return Ok(result);
        }
    }
}