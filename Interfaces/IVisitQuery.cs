using SoftifyGEO.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Interfaces
{
    public interface IVisitQuery
    {
       string GetVisitCustomerList(string pageIndex, string pageSize, string searchdata);
        string GetAllVisitCustomerList(string searchdata, string custtype, string dtfrom,  string dtto);
        string GetVisitDetailsByLocCustId(int id);
    }
}
