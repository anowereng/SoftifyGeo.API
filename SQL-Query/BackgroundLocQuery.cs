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
    public class BackgroundLocQuery : IBackgroundLocQuery
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BackgroundLocQuery(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string SaveBackground(BackgroundLocation model)
        {
            //var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            //if (string.IsNullOrEmpty(userid))
            //    throw new InvalidOperationException("User Not found");

            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            Guid guid = Guid.NewGuid();
            var sqlQuery = "Insert Into tbl_background_location(id, lat, lng, speed)" +
                      " Values ( '" + guid.ToString() + "', '" + model.lat + "','" + model.lng + "', '" + model.speed + "')";
            arrayList.Add(sqlQuery);

            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }
    }
}