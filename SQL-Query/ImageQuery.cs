using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SoftifyGEO.API.Controllers;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using SoftifyGEO.API.Interfaces;
using System.Data.SqlTypes;

namespace SoftifyGEO.API.SQL_Query
{
    public class UploadImageQuery : IUploadImageQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UploadImageQuery(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string UpdateImage(string pagename, string imagename)
        {
            try
            {
                var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
                if (string.IsNullOrEmpty(userid))
                    throw new InvalidOperationException("User Not found");
                else if (string.IsNullOrEmpty(pagename))
                    throw new InvalidOperationException("Page Name check !!");
                CoreSQLConnection CoreSQL = new CoreSQLConnection();
                ArrayList arrayList = new ArrayList();
                var Query = ""; double NewId = 0; var sqlQuery = "";
                if (pagename == "attendance")
                {
                        Query = "SELECT   cast(Isnull(MAX(LocAttendId),0) + 1 AS float)  AS LocAttendId FROM tbl_Location_Attendance where LUserId = " + userid + " and dtCheckOut = null";
                        NewId = CoreSQL.CoreSQL_GetDoubleData(Query);
                        sqlQuery = "Update tbl_Location_Attendance set CheckInImage ='" + imagename + "'";
                }
                else if (pagename == "custcheckin")
                {
                    Query = "SELECT   cast(Isnull(MAX(LocationCustId),0) + 1 AS float)  AS LocationCustId FROM tbl_Location_Customer where LUserId = " + userid + " and dtCheckOutEntry = null";
                    NewId = CoreSQL.CoreSQL_GetDoubleData(Query);
                    sqlQuery = "Update tbl_Location_Customer set CheckInImage ='" + imagename + "'";
                }
                arrayList.Add(sqlQuery);
                CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
                return "Success";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}