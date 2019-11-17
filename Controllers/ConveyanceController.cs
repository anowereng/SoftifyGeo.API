using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sampan;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net;
using SoftifyGEO.API.Interfaces;

namespace SoftifyGEO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConveyanceController : ControllerBase
    {
        private readonly IConveyanceQuery _conveyanceQuery;
        public ConveyanceController(IConveyanceQuery conveyanceQuery) { _conveyanceQuery = conveyanceQuery; }

        [HttpGet("GetConveyType")]
        public IActionResult GetConveyType()
        {
            try
            {
                var list = _conveyanceQuery.GetConveyType();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("SaveConveyance")]
        public IActionResult SaveConveyance([FromBody]Conveyance model)
        {
            try
            {
                _conveyanceQuery.SaveUpdateConveyance(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
