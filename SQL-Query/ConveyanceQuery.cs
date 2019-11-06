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
    }
}