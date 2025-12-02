using Inventory.IServices.BASE;
using Inventory.Model.ViewModels;
using JCZY.CAP.Message;

namespace Inventory.IServices.Consumers
{
    public interface IInventoryConsumers : IBaseServices<Model.Models.Inventory>
    {
        Task<MessageData<InventoryDeductResult>> DeductInventory(MessageData<OrderDto> messageData);
    }
}
