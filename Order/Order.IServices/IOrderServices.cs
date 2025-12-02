using Order.IServices.BASE;
using Order.Model.ViewModels;

namespace Order.IServices
{
    public interface IOrderServices : IBaseServices<Model.Models.Order>
    {
        Task<OrderDto> CreatOrder(OrderDto orderDto);
    }
}