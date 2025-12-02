namespace Order.Model.ViewModels
{
    public class OrderDto
    {
        public long? Id { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
