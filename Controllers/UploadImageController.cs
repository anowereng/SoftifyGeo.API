using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftifyGEO.API.Helpers;
using SoftifyGEO.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace SoftifyGEO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : Controller
    {
        private readonly IUploadImageQuery imageQuery;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UploadImageController(IUploadImageQuery imagequery, IHttpContextAccessor httpContextAccessor)
        {
             imageQuery = imagequery;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Upload"), DisableRequestSizeLimit]
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
                    fileName = pagename + "_0" + userid + "_" + DateTime.Now.ToString("MMddyyyyhhmmtt") + ".jpg";
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
    }
}