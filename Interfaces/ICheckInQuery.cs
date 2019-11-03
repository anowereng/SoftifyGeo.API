using SoftifyGEO.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Interfaces
{
    public interface ICheckInQuery 
    {
        string CheckInSave(CustomerCheckInOut model);
        string GetLastCheckInInfo();
        double GetReadyForNewCheckIn();
    }
}
