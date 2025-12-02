namespace Order.Model.ViewModels
{
    public class InventoryDeductResult
    {
        public bool Successed { get; set; } = true;

        public long? OrderId { get; set; }
    }
}
