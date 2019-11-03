using Sampan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Models
{
    public class LocationAttendance
    {
        public int AttendanceId { get; set; }
        public string UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Accuracy { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }



    }
}
