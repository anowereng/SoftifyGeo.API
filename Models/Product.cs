using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SoftifyGEO.API.Models
{
    public class Product
    {
        //SupplierId, ProductId, ProductName, OPQty, SellPrice, UnitId, CostPrice, Currency, Total, LUserId, ComId, 

        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string ProductName { get; set; }
        public float OPQty { get; set; }
        public float SellPrice { get; set; }
        public int UnitId { get; set; }
        public float CostPrice { get; set; }
        public string Currency { get; set; }
        
    }
}