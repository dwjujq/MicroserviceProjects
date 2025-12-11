using Order.IServices.BASE;
using Order.Model.ViewModels;
using JCZY.CAP.Message;

namespace Order.IServices.Consumers
{
    public interface IOrderConsumers : IBaseServices<Model.Models.Order>
    {
        Task OrderCancel(MessageData<InventoryDeductResult> messageData);
    }
}
