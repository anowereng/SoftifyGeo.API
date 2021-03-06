﻿using SoftifyGEO.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Interfaces
{
    public interface IAttendanceQuery
    {
        double GetAttendanceStatus();
        string AttendanceSave(LocationAttendance model);
    }
}
