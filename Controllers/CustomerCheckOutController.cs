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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerChekOutController : Controller
    {
        private readonly ICheckInQuery _checkInQuery;
        private readonly ICheckOutQuery _checkoutQuery;
        public CustomerChekOutController(ICheckInQuery checkInQuery, ICheckOutQuery checkOutQuery) {
            _checkInQuery = checkInQuery;
            _checkoutQuery = checkOutQuery;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerCheckInOut model)
        {
            try
            {
                if (model != null)
                {
                    _checkoutQuery.CheckOutUpdate(model);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); };
        }
        [HttpGet]
        public ActionResult GetLastCheckInInfo()
        {
            try
            {
                var data = _checkInQuery.GetLastCheckInInfo();
                if (data != null)
                    return Ok(data);
                else
                    return BadRequest();
            }
            catch (Exception ex) { return BadRequest(ex.Message); };
        }

    }
}
