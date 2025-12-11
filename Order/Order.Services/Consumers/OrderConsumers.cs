using DotNetCore.CAP;
using JCZY.CAP.Message;
using Microsoft.Extensions.DependencyInjection;
using Order.IRepository.Base;
using Order.IServices.Consumers;
using Order.Model.CustomEnums;
using Order.Model.ViewModels;
using Order.Services.BASE;

namespace Order.Services.Consumers
{
    public class OrderConsumers : BaseServices<Model.Models.Order>, IOrderConsumers,ICapSubscribe
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageTracker _messageTracker;

        public OrderConsumers(IMessageTracker messageTracker, IServiceProvider serviceProvider)
        {
            _messageTracker = messageTracker;
            _serviceProvider = serviceProvider;
            BaseDal = _serviceProvider.GetRequiredService<IBaseRepository<Model.Models.Order>>();
        }

        [CapSubscribe("order.cancel")]
        public async Task OrderCancel(MessageData<InventoryDeductResult> messageData)
        {
            if (_messageTracker.HasProcessed(messageData.Id))
                return;

            var inventoryDeductResult = messageData.MessageBody;
            if (inventoryDeductResult.Successed)
            {
                _messageTracker.MarkAsProcessed(messageData.Id);
                return;
            }

            var order = await BaseDal.QueryById(inventoryDeductResult.OrderId.Value);
            order.Status = OrderStatus.Canceled;

            await BaseDal.Update(order);

            _messageTracker.MarkAsProcessed(messageData.Id);

        }
    }
}
