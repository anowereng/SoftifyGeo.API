using SoftifyGEO.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Interfaces
{
    public interface IUploadImageQuery
    {
       string UpdateImage(string pagename, string imagename);
    }
}
