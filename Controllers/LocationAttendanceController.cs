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
        private readonly IImageQuery imageQuery;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LocationAttendanceController(IAttendanceQuery attendanceQuery, IImageQuery imagequery , IHttpContextAccessor httpContextAccessor) {
            _attendanceQuery = attendanceQuery;
            imageQuery = imagequery;
            _httpContextAccessor = httpContextAccessor;
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

        [HttpPost("Uplaod"), DisableRequestSizeLimit]
        public IActionResult Upload(string pagename)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var userid = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName =  "attendance" + "_0" + userid + "_" + DateTime.Now.ToString("dd-MMM-yyyy")+".jpg";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    imageQuery.UpdateImage(pagename, fileName);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public void FileUplaod()
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
        }
    }
}
