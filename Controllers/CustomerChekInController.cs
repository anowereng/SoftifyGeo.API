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
using Microsoft.AspNetCore.Http;
using SoftifyGEO.API.Interfaces;

namespace SoftifyGEO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerChekInController : Controller
    {
        private readonly ICheckInQuery _checkInQuery;
        public CustomerChekInController(ICheckInQuery checkInQuery){ _checkInQuery = checkInQuery;}

        [HttpGet("{searchdata}")]
        public ActionResult Get(string searchdata = "")
        {
            CustomerCheckInOut _lQuery = new CustomerCheckInOut();
            var list = _lQuery.GetCustomer(searchdata.ToLower());
            if (list != null)
                return Ok(list);
            else
                return BadRequest(searchdata);
        }

        [HttpGet("GetReadyForCheckIn")]
        public ActionResult GetReadyForNewCheckIn()
        {
            var result = _checkInQuery.GetReadyForNewCheckIn();
            if (result != 0)
                return Ok(JsonConvert.SerializeObject(false));
            else
                return Ok(JsonConvert.SerializeObject(true));
        }

        [HttpPost("CheckIn")]
        public IActionResult CheckIn([FromBody]CustomerCheckInOut model)
        {
            //var _lQuery = new CheckInQuery();
            try
            {
                if (model != null)
                {
                    _checkInQuery.CheckInSave(model);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); };
        }

    }
}
