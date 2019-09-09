using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftifyGEO.API.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using SoftifyGEO.API.SQL_Query;
using Newtonsoft.Json;
using Sampan;

namespace SoftifyGEO.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerChekInOutController : ControllerBase
    {

        [HttpGet("{searchdata}")]
        public ActionResult Get(string searchdata="")
        {
            CustomerCheckInOut _lQuery = new CustomerCheckInOut();
            //return Ok(searchdata);
            var list = _lQuery.GetCustomer(searchdata.ToLower());
            if (list != null)
                return Ok(list);
            else
                return BadRequest(searchdata);
        }

        //[HttpGet("{id}")]
        //public ActionResult Get(int id)
        //{
        //    var data = new List<string>();
        //    CoreSQLConnection CoreSQL = new CoreSQLConnection();
        //    var Query = "select cast( dbo.fnc_CheckInOutSatus('" + id + "') AS float)  AS ProductId";
        //    var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);
        //    if (NewId == 0)
        //        return Ok(JsonConvert.SerializeObject("CheckIn"));
        //    else
        //        return Ok(JsonConvert.SerializeObject("CheckOut"));
        //}


        [HttpPost("DataSave")]
        public IActionResult DataSave([FromBody]Product model)
        {
           ProductQuery _lQuery = new ProductQuery();
            if (model!=null)
            {
                string message =_lQuery.ProductAdd(model);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           
        }
      


    }
}
