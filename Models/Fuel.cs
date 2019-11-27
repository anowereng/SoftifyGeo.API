using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
namespace SoftifyGEO.API.Models
{
    public class Fuel 
    {
        public int FuelIssueId { get; set; }
        public DateTime dtFuel { get; set; }
        public string Description { get; set; }
        public float FuelAmount { get; set; }
    }
}