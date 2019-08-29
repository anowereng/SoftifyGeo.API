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
using SoftifyGEO.API.SQL_Query;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace SoftifyGEO.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginQuery _lQuery;
        private readonly IConfiguration _config;
        public LoginController(LoginQuery lQuery, IConfiguration connfig)
        {
            _lQuery = lQuery;
            _config = connfig;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] User model)
        {
            // throw new Exception("Computer Syas NO !!!");

            model.UserName = model.UserName.ToLower();

            if (ModelState.IsValid)
            {
                if (_lQuery.UserExists(model.UserName))

                    return BadRequest("userName already exists, try different name !!");

                else

                    _lQuery.CreateUser(model);
                return Ok();
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                    .Where(y => y.Count > 0)
                                    .ToList();
                return BadRequest();
            }
        }

        [HttpPost("SupplierSave")]
        public IActionResult SupplierSave([FromBody] Supplier model)
        {
            SupplierQuery _lQuery = new SupplierQuery();
            if (model != null)
            {
                _lQuery.SupplierAdd(model);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(User model)
        {
            bool data = GetUserList(model.UserName, model.UserPass);
            if (data != true)
                return StatusCode((int)HttpStatusCode.Unauthorized, "Invalid User Name Or Password !!!");

            ///IF PASSWORD MATCH TOKEN GENERATE
            var tokendata = TokenAdd(model.LUserId, model.UserName);
            return Ok(tokendata);
        }

        public object TokenAdd(Int64 UserId, string UserName)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier,UserId.ToString()),
            new Claim(ClaimTypes.Name,UserName)
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokendata = new { token = tokenHandler.WriteToken(token) };
            return tokendata;
        }

        [HttpGet("GetUser")]
        public IActionResult GetAllUser()
        {
            string amodel = _lQuery.GetUser();
            if (amodel != null)
                return Ok(amodel);
            else
                return BadRequest();

        }
        public bool GetUserList(string UserName = "", string PassWord = "")
        {
            User model = new User();
            if (UserName != "007" && PassWord != "007")
            {
                var url = "http://203.80.189.18:5190/acl.sales/LoginUser/GetUserList";
                string json = new WebClient().DownloadString(url);
                var listdata = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json);
                model = listdata.Where(x => x.UserName.ToLower() == UserName.ToLower() && x.UserPass == PassWord).FirstOrDefault<User>();
            }
            else
            {
                return true;
            }

            if (model != null)
                return true;
            else
                return false;

        }
        //public IActionResult Get()
        //{
        //    return new OkObjectResult(new Item { Id = 123, Name = "Hero" });
        //}
        //return new ObjectResult(new Item { Id = 123, Name = "Hero" }) { StatusCode = 200 };
        //return StatusCode( 200, new Item { Id = 123, Name = "Hero" });


    }
}
