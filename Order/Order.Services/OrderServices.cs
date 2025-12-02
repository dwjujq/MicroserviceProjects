using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Order.Common.Utility;
using Order.IServices;
using Order.Model.CustomEnums;
using Order.Model.ViewModels;
using Order.Services.BASE;

namespace Inventory.Services
{
    public partial class OrderServices : BaseServices<Order.Model.Models.Order>, IOrderServices
    {
        IHttpContextAccessor _httpContextAccessor;
        private readonly ICapPublisher _capPublisher;
        ILogger<OrderServices> _logger;
        public OrderServices(ILogger<OrderServices> logger, IHttpContextAccessor httpContextAccessor,ICapPublisher capPublisher)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _capPublisher = capPublisher;
        }

        public async Task<OrderDto> CreatOrder(OrderDto orderDto)
        {
            using (var trans = _dbContext.Database.BeginTransaction(_capPublisher, autoCommit: true))
            {
                var order = new Order.Model.Models.Order
                {
                    Id = IdGeneratorUtility.NextId(),
                    ProductId = orderDto.ProductId,
                    Quantity = orderDto.Quantity,
                    CreatedDate = DateTime.Now,
                    Status = OrderStatus.Created
                };
                _dbContext.Order.Add(order);
                var flag = await _dbContext.SaveChangesAsync();

                //throw new Exception("ewrrrrrr");

                if (flag == 1)
                {
                    orderDto.Id = order.Id;

                    var messageData = new MessageData<OrderDto>(orderDto);
                    await _capPublisher.PublishAsync("order.created", messageData, "order.cancel");

                    return orderDto;
                }
                return null;
            }
        }
    }
}
