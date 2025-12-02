using Inventory.IServices.BASE;
using Inventory.Model.ViewModels;

namespace Inventory.IServices
{
    public partial interface IInventoryServices : IBaseServices<Model.Models.Inventory>
    {
        Task<bool> Create(InventoryDto inventoryDto);

        Task DeductInventory(OrderDto orderDto);
    }
}