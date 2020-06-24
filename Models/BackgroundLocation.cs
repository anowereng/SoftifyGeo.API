using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SoftifyGEO.API.Models
{
    public class BackgroundLocation
    {
        public string lat { get; set; }
        public string lng { get; set; }
        public string speed { get; set; }
        public string timestamp { get; set; }
        public string address { get; set; }
    }
}