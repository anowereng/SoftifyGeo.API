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

namespace SoftifyGEO.API.SQL_Query
{
    public class CheckInQuery : ICheckInQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CheckInQuery(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static DataSet dsList = new DataSet();
        public string CheckInSave(CustomerCheckInOut model)
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User Not found");
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var Query = "SELECT  cast(Isnull(MAX(LocationCustId),0) + 1 AS float)  AS BinId FROM tbl_Location_Customer";
            var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

            var sqlQuery = "Insert Into tbl_Location_Customer(LocationCustId,  CustType, CustId, CustName, LUserId, CheckInlatitude,CheckInlongitude, CheckInAddress, CheckInDescription)" +
                           " Values ('" + NewId + "','" + model.CustType + "','" + model.CustId + "', '" + model.CustName + "','" + userid + "', '" + model.CheckInLatitude + "' ,'" + model.CheckInLongitude + "',  N'" + model.CheckInAddress.Replace("'","`") + "', N'" + model.CheckInDescription.Replace("'", "`") + "')";
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

        public string GetLastCheckInInfo()
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User Not found");
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            dsList = new DataSet();
            string strQuery = "Exec [prcGet_CheckOut] '" + userid + "' ";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }


        public double GetReadyForNewCheckIn()
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            var Query = "select cast( dbo.fnc_CheckInOutSatus('" + userid + "') AS float)  AS LocAttendId";
            var id = CoreSQL.CoreSQL_GetDoubleData(Query);
            return id;
        }

    }
}