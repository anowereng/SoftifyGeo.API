using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
using SoftifyGEO.API.Interfaces;

namespace SoftifyGEO.API.SQL_Query
{
    public class CheckOutQuery: ICheckOutQuery
    {
        public static DataSet dsList = new DataSet();
        public string CheckOutUpdate(CustomerCheckInOut model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var sqlQuery = "Update tbl_Location_Customer set CheckOutAddress = '" + model.CheckOutAddress + "', CheckOutLatitude = '" + model.CheckOutLatitude + "', CheckOutLongitude = '" + model.CheckOutLongitude + "', dtCheckOutEntry = getdate()  where LocationCustId = '" + model.LocationCustId+"'";
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

    }
}