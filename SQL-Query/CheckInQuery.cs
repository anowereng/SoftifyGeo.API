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

namespace SoftifyGEO.API.SQL_Query
{
    public class CheckInQuery
    {
        
        public static DataSet dsList = new DataSet();
        public string CheckInSave(CustomerCheckInOut model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var Query = "SELECT  cast(Isnull(MAX(LocationCustId),0) + 1 AS float)  AS BinId FROM tbl_Location_Customer";
            var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

            var sqlQuery = "Insert Into tbl_Location_Customer(LocationCustId,  CustType, CustId, CustName, LUserId, CheckInlatitude,CheckInlongitude, CheckInAddress)" +
                           " Values ('" + NewId + "','" + model.CustType + "','" + model.CustId + "', '" + model.CustName + "','" + model.LUserId + "', '" + model.CheckInLatitude + "' ,'" + model.CheckInLongitude + "',  '" + model.CheckInAddress + "' )";
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

        public string GetLastCheckInInfo(int userid)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            dsList = new DataSet();
            string strQuery = "Exec [prcGet_CheckOut] '" + userid + "' ";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }
    }
}