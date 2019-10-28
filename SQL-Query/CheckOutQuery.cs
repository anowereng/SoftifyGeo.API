using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
namespace SoftifyGEO.API.SQL_Query
{
    public class CheckOutQuery
    {
        public static DataSet dsList = new DataSet();
        public string CheckOutUpdate(CustomerCheckInOut model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var sqlQuery = "Update tbl_Location_Customer set values CheckOutAddress = '" + model.CheckOutAddress + "', CheckOutLatitude = '" + model.CheckOutLatitude + "', dtCheckOutEntry = getdate() , CheckOutAddress=  '" + model.CheckOutAddress + "' where LocationCustId = '"+model.CustId+"'  )";
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

    }
}