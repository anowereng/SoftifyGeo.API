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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDemoController : ControllerBase
    {
        // GET api/values
        [HttpGet("GetProductData/{id:int}")]
        public IActionResult GetProductData(int id)
        {
            ProductDemoQuery _lQuery = new ProductDemoQuery();
            var list = _lQuery.GetProduct(id);
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        [HttpGet("GetProductList")]
        public IActionResult GetProductList()
        {
            ProductDemoQuery _lQuery = new ProductDemoQuery();
            var list = _lQuery.GetProductList();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        [HttpPost("ProductSave")]
        public IActionResult ProductSave([FromBody]Product model)
        {
           ProductDemoQuery _lQuery = new ProductDemoQuery();
            if (model!=null)
            {
                string message =_lQuery.ProductAdd(model);
                //if(message=="Success")
                return Ok("Successfully Saved");
            }
            else
            {
                return BadRequest();
            }
           
        }
        [HttpPut("ProductUpdate/{id:int}")]
        public IActionResult ProductUpdate(int id, [FromBody]Product model)
        {

           ProductDemoQuery _lQuery = new ProductDemoQuery();
            if (model != null)
            {
                string message = _lQuery.ProductUpdate(model);
                //if(message=="Success")
                return Ok("Successfully Update");
            }
            else
            {
                return BadRequest();
            }
        }
   
        // DELETE api/values/5
        [HttpDelete("ProductDelete/{id:int}")]
        public IActionResult ProductDelete(int id)
        {
           ProductDemoQuery _lQuery = new ProductDemoQuery();
            if (id != null)
            {
                string message = _lQuery.ProductDelete(id);
                //if(message=="Success")
                return Ok("Successfully delete");
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
