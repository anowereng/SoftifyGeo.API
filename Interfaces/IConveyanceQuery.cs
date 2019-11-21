using SoftifyGEO.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Interfaces
{
    public interface IConveyanceQuery
    {
        string GetConveyType();
        string SaveConveyance(Conveyance model);
        void SaveUpdateConveyance(Conveyance model);
        string GetConveyInfo(int visitid);
    }
}
