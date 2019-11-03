using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sampan;

namespace SoftifyGEO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
        //var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName
        //var userEmail = User.FindFirstValue(ClaimTypes.Email); // will give the user's Email
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "value";
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
        //[HttpGet("ProductSave{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    CoreSQLConnection CoreSQL = new CoreSQLConnection();
        //    var Query = "select cast( dbo.fnc_CheckInOutSatus('" + id + "') AS float)  AS ProductId";
        //    var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

        //    if (NewId > 0)
        //        return Ok("CheckOut");
        //    else
        //        return Ok("CheckIn");

        //}
    }
}
