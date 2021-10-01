using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.DB
{
    public partial class Order
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public int? UserId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? ShippingAddressId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDueDate { get; set; }
        public decimal? OrderTotal { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Address ShippingAddress { get; set; }
        public virtual User User { get; set; }
    }
}
