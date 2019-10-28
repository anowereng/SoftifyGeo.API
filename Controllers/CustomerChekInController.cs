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
    public class CustomerChekInController : Controller
    {
        [HttpGet("{searchdata}")]
        public ActionResult Get(string searchdata="")
         {
            CustomerCheckInOut _lQuery = new CustomerCheckInOut();
            var list = _lQuery.GetCustomer(searchdata.ToLower());
            if (list != null)
                return Ok(list);
            else
                return BadRequest(searchdata);
        }

        [HttpPost("CheckIn")]
        public IActionResult CheckIn([FromBody]CustomerCheckInOut model)
        {
            var _lQuery = new CheckInQuery();
            try
            {
                if (model != null)
                {
                    _lQuery.CheckInSave(model);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex) { return BadRequest(ex.Message); };
        }

    }
}
