using JCZY.CAP.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.IServices;
using Order.Model.ViewModels;


namespace Order.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Order")]
    [AllowAnonymous]
    public class OrderController : BaseApiController
    {
        readonly IOrderServices _orderServices;
        private readonly IMessageTracker _messageTracker;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderServices orderServices,  ILogger<OrderController> logger, IMessageTracker messageTracker)
        {
            _orderServices = orderServices;
            _logger = logger;
            _messageTracker = messageTracker;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderDto orderDto)
        {
            var order = await _orderServices.CreatOrder(orderDto);
            return Ok();
        }

        //[CapSubscribe("order.cancel")]
        [NonAction]
        public async Task OrderCancel(MessageData<InventoryDeductResult> messageData)
        {
            if (_messageTracker.HasProcessed(messageData.Id))
                return;

           

            _messageTracker.MarkAsProcessed(messageData.Id);

        }
    }
}