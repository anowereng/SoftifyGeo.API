﻿using System;
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
    public class VisitController : ControllerBase
    {
        private readonly IVisitQuery _visitQuery;
        public VisitController(IVisitQuery visitQuery) { _visitQuery = visitQuery; }

        [HttpGet("GetVisitDetailsByLocCustId")]
        public IActionResult GetVisitDetailsByLocCustId(int id)
        {
            try
            {
                var list = _visitQuery.GetVisitDetailsByLocCustId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // For test purpose
        [HttpGet("GetVisitList")]
        public IActionResult Get( string pageindex ,string pagesize, string searchdata)
        {
            try
            {
                var list = _visitQuery.GetVisitCustomerList(pageindex, pagesize, searchdata);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllVisitCustomer")]
        public IActionResult GetAllVisitCustomer(string searchdata, string custtype, string dtfrom, string dtto)
        {
            try
            {
                var list = _visitQuery.GetAllVisitCustomerList(searchdata, custtype, dtfrom,  dtto);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
