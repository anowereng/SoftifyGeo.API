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
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace SoftifyGEO.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationAttendanceController : ControllerBase
    {
        private readonly IAttendanceQuery _attendanceQuery;
        public LocationAttendanceController(IAttendanceQuery attendanceQuery) {
            _attendanceQuery = attendanceQuery;
        }

        [HttpPost("AttendanceSave"), DisableRequestSizeLimit]
        public IActionResult AttendanceSave([FromBody]LocationAttendance model)
        {
            try
            {
                if (_attendanceQuery.AttendanceSave(model) == "Success")
                {
                    return Ok();
                }
                else { return BadRequest("Save Failed !!!"); }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (_attendanceQuery.GetAttendanceStatus() == 0)
                    return Ok(JsonConvert.SerializeObject("CheckIn"));
                else
                    return Ok(JsonConvert.SerializeObject("CheckOut"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      

       
    }
}
