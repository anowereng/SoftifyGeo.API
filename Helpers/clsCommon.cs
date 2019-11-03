using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using Newtonsoft.Json;
namespace SoftifyGEO.API.Helpers
{
    public class clsCommon
    {
        public static string ControllerNameP { get; set; }
        public static string ActionNameP { get; set; }
        public static int ComID { get; set; }
        public static int UserID { get; set; }

        #region Combo
        public class clsCombo1
        {
            public string Name { get; set; }
        }

        internal static void JsonSerialize(object p)
        {
            throw new NotImplementedException();
        }

        public class clsCombo2
        {
            public Int64 Id { get; set; }
            public string Name { get; set; }
        }

        public class clsCombo3
        {
            public Int64 Id { get; set; }
            public string Name { get; set; }
            public Int64 SubId { get; set; }
        }
        public class clsCombo4
        {
            public Int64 Id { get; set; }
            public string Name { get; set; }
            public Int64 SubId { get; set; }
            public string SubName { get; set; }
        }
        #endregion Combo

        public static List<dynamic> ToDynamicList(DataTable dt)
        {
            var list = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                list.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            return list;
        }
        //start : jsonConverter
        public static string JsonSerialize(DataTable dt)
        {
            //DataTable dt = (DataTable)dsData.Tables[0];

            JsonSerializer jsSerializer = new JsonSerializer();
            jsSerializer.MaxDepth = 500000000;

            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }

            dt.Dispose();
            return JsonConvert.SerializeObject(parentRow);
        }
        //end : jsonConverter
        public static string JsonSerializeDataSet(DataSet ds)
        {
            ds.AcceptChanges();
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }


    }

    public static class clsGenerateList
    {
        public static List<clsCommon.clsCombo1> prcColumnOne(DataTable dt)
        {
            List<clsCommon.clsCombo1> list = new List<clsCommon.clsCombo1>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                clsCommon.clsCombo1 item = new clsCommon.clsCombo1();
                item.Name = dt.Rows[i][0].ToString();
                list.Add(item);
            }
            return list;
        }
        public static List<clsCommon.clsCombo2> prcColumnTwo(DataTable dt)
        {
            List<clsCommon.clsCombo2> list = new List<clsCommon.clsCombo2>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                clsCommon.clsCombo2 item = new clsCommon.clsCombo2();
                item.Id = Int64.Parse(dt.Rows[i][0].ToString());
                item.Name = dt.Rows[i][1].ToString();
                list.Add(item);
            }
            return list;
        }

        public static List<clsCommon.clsCombo3> prcColumnThree(DataTable dt)
        {
            List<clsCommon.clsCombo3> list = new List<clsCommon.clsCombo3>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                clsCommon.clsCombo3 item = new clsCommon.clsCombo3();
                item.Id = Int64.Parse(dt.Rows[i][0].ToString());
                item.Name = dt.Rows[i][1].ToString();
                item.SubId = Int64.Parse(dt.Rows[i][2].ToString());
                list.Add(item);
            }
            return list;
        }
        public static List<clsCommon.clsCombo4> prcColumnFour(DataTable dt)
        {
            List<clsCommon.clsCombo4> list = new List<clsCommon.clsCombo4>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                clsCommon.clsCombo4 item = new clsCommon.clsCombo4();
                item.Id = Int64.Parse(dt.Rows[i][0].ToString());
                item.Name = dt.Rows[i][1].ToString();
                item.SubId = Int64.Parse(dt.Rows[i][2].ToString());
                item.SubName = dt.Rows[i][3].ToString();
                list.Add(item);
            }
            return list;
        }
        public static List<clsCommon.clsCombo2> prcColumnTwo(DataRow[] datarow)
        {
            List<clsCommon.clsCombo2> list = new List<clsCommon.clsCombo2>();

            foreach (DataRow dr in datarow)
            {
                clsCommon.clsCombo2 item = new clsCommon.clsCombo2();
                item.Id = Int64.Parse(dr[0].ToString());
                item.Name = dr[1].ToString();
                list.Add(item);
            }
            return list;
        }

    }



    public class CommonModel
    {
        public string InsertData(string db, string table, Array data)
        {
            string sqlQuery = "INSERT INTO " + db + ".dbo." + table + " Values(" + data + " )";

            return "Test";
        }
    }

  
}