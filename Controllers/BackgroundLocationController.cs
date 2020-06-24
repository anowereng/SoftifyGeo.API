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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundLocationController : ControllerBase
    {
        private readonly IBackgroundLocQuery _backgroundLocQuery;
        public BackgroundLocationController(IBackgroundLocQuery backgroundLocQuery) { _backgroundLocQuery = backgroundLocQuery; }

        [HttpPost("SaveBackground")]
        public IActionResult SaveBackground([FromBody]BackgroundLocation model)
        {
            try
            {
                _backgroundLocQuery.SaveBackground(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("SaveBackground")]
        public IActionResult SaveBackground(int id)
        {
            try
            {
                //_backgroundLocQuery.SaveBackground(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
