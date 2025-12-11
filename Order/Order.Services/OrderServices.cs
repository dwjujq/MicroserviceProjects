using DotNetCore.CAP;
using JCZY.CAP;
using JCZY.CAP.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Order.Common.Utility;
using Order.IServices;
using Order.Model.CustomEnums;
using Order.Model.ViewModels;
using Order.Services.BASE;

namespace Order.Services
{
    public class OrderServices : BaseServices<Model.Models.Order>, IOrderServices
    {
        private readonly ICapPublisher _capPublisher;
        ILogger<OrderServices> _logger;
        public OrderServices(ILogger<OrderServices> logger, ICapPublisher capPublisher)
        {
            _logger = logger;
            _capPublisher = capPublisher;
        }

        public async Task<OrderDto> CreatOrder(OrderDto orderDto)
        {
            using (var trans = Db.BeginCapTransaction(_capPublisher, autoCommit: false))
            {
                try
                {
                    var order = new Order.Model.Models.Order
                    {
                        Id = IdGeneratorUtility.NextId(),
                        ProductId = orderDto.ProductId,
                        Quantity = orderDto.Quantity,
                        CreatedDate = DateTime.Now,
                        Status = OrderStatus.Created
                    };
                    var id = await BaseDal.Add(order);

                    if (id>0)
                    {
                        orderDto.Id = order.Id;

                        var messageData = new MessageData<OrderDto>(orderDto);
                        await _capPublisher.PublishAsync("order.created", messageData, "order.cancel");

                        //throw new Exception("ewrrrrrr");

                        trans.Commit();

                        return orderDto;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,ex.Message);
                    trans.Rollback();
                    return null;
                }
            }
        }
    }
}
