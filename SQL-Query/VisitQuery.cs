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
    public class VisitQuery : IVisitQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
      
        public VisitQuery(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetVisitCustomerList(string pageindex , string pagesize, string searchdata)
       {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            DataSet dsList = new DataSet();
            string strQuery = "Exec [prcDynamic_search_Assignment1]  @PageIndex = '" + pageindex + "', @PageSize = '" + pagesize + "', @Name = '" + searchdata + "'  , @OrderBy ='Name' ";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }

        public string GetAllVisitCustomerList(string searchdata, string custtype, string dtfrom, string dtto)
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            DataSet dsList = new DataSet();
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User Not found");
            string strQuery = "Exec [prcGet_VisitCustomerList]  @UserId = '" + userid + "',  @Name = '"+ searchdata + "', @Type = '" + custtype + "',  @dtFrom = '" + dtfrom + "', @dtTo='" + dtto + "'";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }

        public string GetVisitDetailsByLocCustId(int id)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            DataSet dsList = new DataSet();
            string strQuery = "Exec [prcGet_VisitDetails] '" + id + "' ";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }
    }
}