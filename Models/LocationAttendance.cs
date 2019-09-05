using Sampan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftifyGEO.API.Models
{
    public class LocationAttendance
    {
        public int AttendanceId { get; set; }
        public string UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Accuracy { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public string AttendanceSave(LocationAttendance model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();

           
            var sqlQuery = "exec prc_AttCheckInOut '"+model.UserId+"','"+model.Type+"','"+model.Latitude+"', '"+model.Longitude+"', '"+model.Address+"'";
            //var Query = "SELECT  cast(Isnull(MAX(LocationAttendId),0) + 1 AS float)  AS LocationAttendId FROM tbl_Location_Attendance";
            //var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

            //var sqlQuery = "Insert Into tbl_Product (LocationAttendId, LUserId, latitude, longitude, address, dtAttendEntry)" +
            //               " Values ('" + NewId + "','" + 1 + "','" + model.Latitude + "','" + model.Longitude + "', '" + model.Address + "')";
            arrayList.Add(sqlQuery);

            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

    }
}
