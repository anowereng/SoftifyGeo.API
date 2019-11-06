using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
using SoftifyGEO.API.Interfaces;
using Microsoft.AspNetCore.Http;

namespace SoftifyGEO.API.SQL_Query
{
    public class AttendanceQuery : IAttendanceQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AttendanceQuery(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string AttendanceSave(LocationAttendance model)
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User Not found");
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var sqlQuery = "exec prc_AttCheckInOut '" + userid + "','" + model.Type + "','" + model.Latitude + "', '" + model.Longitude + "', '" + model.Address + "'";
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

        public double GetAttendanceStatus()
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User Not found");
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            var Query = "select cast( dbo.fnc_Attendance_Status('" + userid + "') AS float)  AS AttendId";
            var result = CoreSQL.CoreSQL_GetDoubleData(Query);
            return result;
        }

    }
}