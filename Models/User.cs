using System;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace SoftifyGEO.API.Models
{

    public class User
    {
        public int LUserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string DisplayName { get; set; }
        public int CatId { get; set; }
        public int RefId { get; set; }
        public bool IsInactive { get; set; }
        public bool IsMaster { get; set; }
        public void prcSetData(DataRow dr)
        {
            LUserId = Int32.Parse(dr["LUserId"].ToString());
            UserName = dr["UserName"].ToString();
            UserPass = dr["UserPass"].ToString();
        }
    }
}