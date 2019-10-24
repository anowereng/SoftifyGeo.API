using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SoftifyGEO.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string ProductName { get; set; }
        public float OPQty { get; set; }
        public float SellPrice { get; set; }
        public int UnitId { get; set; }
        public float CostPrice { get; set; }
        public string Currency { get; set; }
        public string Weight { get; set; }
        public string ROL { get; set; }
        public string BrandId { get; set; }

    }
}