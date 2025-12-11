using DotNetCore.CAP;
using Inventory.IRepository.Base;
using Inventory.IServices.Consumers;
using Inventory.Model.ViewModels;
using Inventory.Services.BASE;
using JCZY.CAP.Message;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Inventory.Services.Consumers
{
    public class InventoryConsumers : BaseServices<Model.Models.Inventory>, IInventoryConsumers,ICapSubscribe
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageTracker _messageTracker;

        public InventoryConsumers(IServiceProvider serviceProvider,IMessageTracker messageTracker)
        {
            _serviceProvider = serviceProvider;
            BaseDal = _serviceProvider.GetRequiredService<IBaseRepository<Model.Models.Inventory>>();
            _messageTracker = messageTracker;
        }

        [CapSubscribe("order.created")]
        public async Task<MessageData<InventoryDeductResult>> DeductInventory(MessageData<OrderDto> messageData)
        {
            var orderDto = messageData.MessageBody;

            if (_messageTracker.HasProcessed(messageData.Id))
                return new MessageData<InventoryDeductResult>(new InventoryDeductResult());

            // （扣减库存）
            var inventories = await base.Query(i => i.ProductId == orderDto.ProductId);
            var inventory = inventories.FirstOrDefault();

            if (inventory.Stock < orderDto.Quantity)
            {
                return new MessageData<InventoryDeductResult>(new InventoryDeductResult { Successed = false, OrderId = orderDto.Id });
            }

            inventory.Stock -= orderDto.Quantity;

            await base.Update(inventory);

            _messageTracker.MarkAsProcessed(messageData.Id);

            return new MessageData<InventoryDeductResult>(new InventoryDeductResult());
        }
    }
}
