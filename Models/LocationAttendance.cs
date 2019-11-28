using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
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
        public string CheckInLatitude { get; set; }
        public string CheckInLongitude { get; set; }
        public string Accuracy { get; set; }
        public string CheckInAddress { get; set; }
        public string Type { get; set; }

    }
}
