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
            try
            {
                CoreSQLConnection CoreSQL = new CoreSQLConnection();
                ArrayList arrayList = new ArrayList();
                if (model.CheckOutAddress == null)
                {
                    model.CheckOutAddress = "";
                }
                var sqlQuery = "Update tbl_Location_Customer set CheckOutAddress = N'" + model.CheckOutAddress.Replace("'", "`") + "', CheckOutDescription = N'" + model.CheckOutDescription.Replace("'", "`") + "', CheckOutLatitude = '" + model.CheckOutLatitude + "', CheckOutLongitude = '" + model.CheckOutLongitude + "',  dtCheckOutEntry = getdate()  where LocationCustId = '" + model.LocationCustId + "'";
                arrayList.Add(sqlQuery);
                CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
                return "Success";

            }
           catch (Exception ex) {
                throw (ex);
            }
        }

    }
}