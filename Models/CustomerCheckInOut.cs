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


        public int CustomerId { get; set; }
        public int CustomerName { get; set; }
        public int CustomerType { get; set; }
        public int SearchValue { get; set; }
        public int UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Address { get; set; }

        public static DataSet dsList = new DataSet();
        public string GetCustomer(string searchdata)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            dsList = new DataSet();
            string strQuery = "Exec prcGet_CustomerList " + searchdata;
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }
    }
}