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
        public int LUserId { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int Address { get; set; }

        public string AttendanceSave(LocationAttendance model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var Query = "SELECT  cast(Isnull(MAX(LocationAttendId),0) + 1 AS float)  AS LocationAttendId FROM tbl_Location_Attendance";
            var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

            var sqlQuery = "Insert Into tbl_Product (LocationAttendId, LUserId, latitude, longitude, address, dtAttendEntry)" +
                           " Values ('" + NewId + "','" + 1 + "','" + model.Latitude + "','" + model.Longitude + "', '" + model.Address + "')";
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

    }
}
