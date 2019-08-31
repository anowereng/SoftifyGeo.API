using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sampan;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace SoftifyGEO.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationAttendanceController : ControllerBase
    {
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] LocationAttendance model)
        {
            if (model.AttendanceSave(model) == "Success")
                return Ok();
            else
                return BadRequest("Save Failed !!!");

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        //// POST api/values
        //[HttpGet("CheckInOutStatus")]
        //public ActionResult<string> CheckInOutStatus(int id = 2)
        //{
        //    CoreSQLConnection CoreSQL = new CoreSQLConnection();
        //    var Query = "SELECT dbo.fnc_CheckInOutSatus('"+ id + "')";
        //    var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

        //    if (NewId > 0)
        //        return Ok("CheckOut");
        //    else
        //        return Ok("CheckIn");

        //}

     

    }
}
