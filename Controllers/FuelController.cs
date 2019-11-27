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
    public class FuelController : Controller
    {
        private readonly IFuelQuery _fuelQuery;
        public FuelController(IFuelQuery fuelQuery){ _fuelQuery = fuelQuery;}

        [HttpPost("Fuel")]
        public IActionResult Fuel([FromBody]Fuel model)
        {
            try
            {
                if (model != null)
                {
                    _fuelQuery.FuelSave(model);
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
