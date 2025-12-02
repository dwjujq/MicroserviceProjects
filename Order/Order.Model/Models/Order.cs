using Order.Model.CustomEnums;

namespace Order.Model.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public class Order : RootEntityTkey<long>
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public OrderStatus Status { get; set; }
    }
}
