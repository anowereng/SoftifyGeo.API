using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Models
{
    public class Supplier
    {
        public  int   SupplierId { get; set; }
        public string SupplierCode  { get; set; }
        public string SupplierName  { get; set; }
        public string SupplierPhone  { get; set; }
        public string ContactEmail  { get; set; }
        public string ContactName  { get; set; }
        public string ContactPhone  { get; set; }
        public string SupplierAddress  { get; set; }
        public int SupplierLocation  { get; set; }
    }
}
