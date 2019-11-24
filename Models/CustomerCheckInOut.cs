using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
namespace SoftifyGEO.API.Models
{
    public class CustomerCheckInOut 
    {
        public int CustId { get; set; }
        public int LocationCustId { get; set; }
        public string CustName { get; set; }
        public string CustType { get; set; }
        public string SearchValue { get; set; }
        public int LUserId { get; set; }
        public string CheckInLatitude { get; set; }
        public string CheckInLongitude { get; set; }
        public string CheckInAddress { get; set; }
        public string CheckOutLatitude { get; set; }
        public string CheckOutLongitude { get; set; }
        public string CheckOutAddress { get; set; }
        public string CheckInDescription { get; set; }
        public string CheckOutDescription{ get; set; }

        public static DataSet dsList = new DataSet();
        public string GetCustomer(string searchdata)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            dsList = new DataSet();
            string strQuery = "Exec [prcGet_CustomerBySearch] " + searchdata;
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }

    }
}