using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SoftifyGEO.API.Models
{
    public class Conveyance
    {
        public int Id { get; set; }
        public string visitId { get; set; }
        public string conveyAmount { get; set; }
        public string conveyTypeId { get; set; }
        //public IList<ConveyanceSub> conveyType { get; set; }
        //public class ConveyanceSub
        //{
        //    public int Id { get; set; }
        //    public int Type { get; set; }
        //    public int Amount { get; set; }
        //}
    }
}