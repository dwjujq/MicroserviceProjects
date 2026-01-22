using DotNetCore.CAP;
using Grpc.Net.Client;
using GrpcGreeterClient;
using Inventory.AuthHelper;
using Inventory.AuthHelper.OverWrite;
using Inventory.Common.Helper;
using Inventory.Common.Swagger;
using Inventory.IServices;
using Inventory.Model;
using Inventory.Model.ViewModels;
using Inventory.Services;
using JCZY.CAP.Message;
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
    public class InventoryController : BaseApiController
    {
        readonly IInventoryServices _inventoryServices;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventoryServices inventoryServices, ILogger<InventoryController> logger)
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

        //[CapSubscribe("order.created")]
        [NonAction]
        public async Task<MessageData<InventoryDeductResult>> DeductInventory(MessageData<OrderDto> messageData)
        {
            var orderDto = messageData.MessageBody;

            

            return new MessageData<InventoryDeductResult>(new InventoryDeductResult());
        }

        [HttpGet]
        public async Task<IActionResult> TestGrpc()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:9291");
            var client = new Greeter.GreeterClient(channel); 
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            return Ok(reply.Message);
        }

        [HttpGet]
        public async Task<IActionResult> TestRefit()
        {
            return Ok("werwerwerwer");
        }
    }
}