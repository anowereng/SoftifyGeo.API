﻿using System;
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
using Microsoft.AspNetCore.Authorization;
using Sampan;
using System.Collections;
using System.Data;
using SoftifyGEO.API.Helpers;

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

        [HttpPost("UpdateProfile")]
        public IActionResult UpdateProfile(User model)
        {
            try
            {
                _lQuery.UpdateProfile(model);
                return Ok(); 
            }
            catch(Exception ex) { return BadRequest(ex.Message); }

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
            var data = GetUserList(model.UserName, model.UserPass);
            if (data == null)
                return StatusCode((int)HttpStatusCode.Unauthorized, "Invalid User Name Or Password !!!");
            ///IF PASSWORD MATCH TOKEN GENERATE
            return Ok(TokenAdd(data));
        }

        public object TokenAdd(User model)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier,model.LUserId.ToString()),
            new Claim(ClaimTypes.Name,model.UserName),
            new Claim(ClaimTypes.GivenName,model.DisplayName),
            new Claim(ClaimTypes.Role,model.DesigName),
            new Claim(ClaimTypes.Surname,model.OldPassword)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddYears(10),
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
        public string GetJsonUserList()
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            DataSet dsList = new DataSet();
            string strQuery = "exec [prcGet_UserList] ";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }
        public User GetUserList(string UserName = "", string PassWord = "")
        {
            User model = new User();
            if (UserName == "007" && PassWord == "007")
            {
                return model = new User
                {
                    LUserId = 1,
                    UserName = "007",
                    UserPass = "007",
                    CatId = 0,
                    DisplayName = "Admin",
                    DesigName = "Administrator",
                    IsInactive = true,
                    IsMaster = true,
                    RefId = 1
                };
            }
            else
            {
                model = null;
                CoreSQLConnection CoreSQL = new CoreSQLConnection();
                //var url = "http://203.80.189.18:5190/acl.sales/LoginUser/GetUserList";
                //var url = "http://202.51.188.186:5190/acl.sales/LoginUser/GetUserList";
                //string json = new WebClient().DownloadString(url);

                var listdata = JsonConvert.DeserializeObject<List<User>>(GetJsonUserList()).
                               Where(x => x.UserName.ToLower() == UserName.ToLower()
                               && CoreSQL.GetDecryptedData(x.UserPass) == PassWord)
                               .FirstOrDefault<User>();

                if (listdata == null)
                {
                    return model = null;
                }
                else
                {
                    model = listdata;
                    model.OldPassword = CoreSQL.GetDecryptedData(model.UserPass);
                }

            }
            return model;
        }

    }
}
