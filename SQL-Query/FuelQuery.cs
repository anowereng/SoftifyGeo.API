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
    public class FuelQuery : IFuelQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FuelQuery(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static DataSet dsList = new DataSet();

        public string FuelSave(Fuel model)
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User Not found");

            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var Query = "SELECT cast(Isnull(MAX(FuelIssueId),0) + 1 AS float)  AS FuelIssueId FROM tbl_FuelIssue";
            var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

            var sqlQuery = "Insert Into tbl_FuelIssue(FuelIssueId, dtFuel, Description, FuelAmount, UserId)" +
                           " Values ('" + NewId + "','" + model.dtFuel + "', N'" + model.Description.Replace("'", "`") + "', '" + model.FuelAmount + "','" + userid + "')";
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

        public string GetFuelList()
        {
            throw new NotImplementedException();
        }
    }
}