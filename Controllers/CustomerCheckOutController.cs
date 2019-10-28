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
    public class CustomerChekOutController : Controller
    {

        [HttpPost("CheckOut")]
        public IActionResult CheckOut([FromBody]CustomerCheckInOut model)
        {
            var _lQuery = new CheckOutQuery();
            try
            {
                if (model != null)
                {
                    _lQuery.CheckOutUpdate(model);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex) { return BadRequest(ex.Message); };
        }

        [HttpGet("{id}")]
        public ActionResult GetLastCheckInInfo(int id)
        {
            var _lQuery = new CheckInQuery();
            try
            {
                if (id > 0)
                {
                   var data = _lQuery.GetLastCheckInInfo(id);
                    if (data!=null)
                        return Ok(data);
                    else
                        return Ok("empty data");
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
