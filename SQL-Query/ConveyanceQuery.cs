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
    public class ConveyanceQuery : IConveyanceQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
      
        public ConveyanceQuery(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetConveyType()
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            DataSet dsList = new DataSet();
            string strQuery = "Exec [prcGet_ConveyanceType]";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }
        public string SaveConveyance(Conveyance model)
        {
            var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User Not found");

            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var Query = "SELECT  cast(Isnull(MAX(ConveyId),0) + 1 AS float)  AS ConveyId FROM tblConveyance_Main";
            var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

            var sqlQuery = "Insert Into tblConveyance_Main(ConveyId, dtConveyance, LUserId)" +
                           " Values ('" + NewId + "', getdate(),'" + userid + "')";
            arrayList.Add(sqlQuery);

            sqlQuery = "Insert Into tblConveyance_Sub(ConveyId, ConveyTypeId, ConveyAmount)" +
                      " Values ('" + NewId + "', '" + model.conveyTypeId + "', '" + model.conveyAmount + "')";
            arrayList.Add(sqlQuery);

       
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

    }
}