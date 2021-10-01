using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.DB
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public string Image { get; set; }
        public string Sku { get; set; }
        public string BarCode { get; set; }
        public int? AvailableQuantity { get; set; }
    }
}
