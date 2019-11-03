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

namespace SoftifyGEO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasicSettingsController : ControllerBase
    {
        // GET api/values

        /* Unit : Start  */
        [HttpGet("GetUnitList")]
        public IActionResult GetUnitList()
        {
              UnitQuery _lQuery = new UnitQuery();
            var list = _lQuery.GetUnit();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        [HttpPost("UnitSave")]
        public IActionResult UnitSave([FromBody] Unit model)
        {
            UnitQuery _lQuery = new UnitQuery();
            if (model!=null)
            {
                string message =_lQuery.UnitAdd(model);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           
        }
         [HttpPut("UnitUpdate/{id:int}")]
        public IActionResult UnitUpdate(int id, [FromBody] Unit model)
        {

            UnitQuery _lQuery = new UnitQuery();
            if (model != null)
            {
                string message = _lQuery.UnitUpdate(model);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
   
        // DELETE api/values/5
        [HttpDelete("UnitDelete/{id:int}")]
        public IActionResult UnitDelete(int id)
        {
           UnitQuery _lQuery = new UnitQuery();
            if (id != null)
            {
                string message = _lQuery.UnitDelete(id);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /* Bin : Start  */
        [HttpGet("GetBinList")]
        public IActionResult GetBinList()
        {
              BinQuery _lQuery = new BinQuery();
            var list = _lQuery.GetBin();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        [HttpPost("BinSave")]
        public IActionResult BinSave([FromBody] Bin model)
        {
            BinQuery _lQuery = new BinQuery();
            if (model!=null)
            {
                string message =_lQuery.BinAdd(model);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           
        }
         [HttpPut("BinUpdate/{id:int}")]
        public IActionResult BinUpdate(int id, [FromBody] Bin model)
        {

            BinQuery _lQuery = new BinQuery();
            if (model != null)
            {
                string message = _lQuery.BinUpdate(model);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
   
        // DELETE api/values/5
        [HttpDelete("BinDelete/{id:int}")]
        public IActionResult BinDelete(int id)
        {
           BinQuery _lQuery = new BinQuery();
            if (id != null)
            {
                string message = _lQuery.BinDelete(id);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



    /* Supplier : Start  */
        [HttpGet("GetSupplierList")]
        public IActionResult GetSupplierList()
        {
            SupplierQuery _lQuery = new SupplierQuery();
            var list = _lQuery.GetSupplier();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        [HttpGet("GetSupplierCombo")]
        public IActionResult GetSupplierCombo()
        {
            SupplierQuery _lQuery = new SupplierQuery();
            var list = _lQuery.GetCombo();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        [HttpPost("SupplierSave")]
        public IActionResult SupplierSave([FromBody] Supplier model)
        {
            SupplierQuery _lQuery = new SupplierQuery();
            if (model!=null)
            {
                string message =_lQuery.SupplierAdd(model);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           
        }
         [HttpPut("SupplierUpdate/{id:int}")]
        public IActionResult SupplierUpdate(int id, [FromBody] Supplier model)
        {

            SupplierQuery _lQuery = new SupplierQuery();
            if (model != null)
            {
                string message = _lQuery.SupplierUpdate(model);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
   
        // DELETE api/values/5
        [HttpDelete("SupplierDelete/{id:int}")]
        public IActionResult SupplierDelete(int id)
        {
           SupplierQuery _lQuery = new SupplierQuery();
            if (id != null)
            {
                string message = _lQuery.SupplierDelete(id);
                //if(message=="Success")
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
