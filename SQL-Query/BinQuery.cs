using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
namespace SoftifyGEO.API.SQL_Query
{
    public class BinQuery
    {
        public static DataSet dsList = new DataSet();
        public string GetBin()
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            dsList = new DataSet();
            string strQuery = "Exec [prcGet_Bin] 0 ";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }

        public string BinAdd(Bin model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var Query = "SELECT  cast(Isnull(MAX(BinId),0) + 1 AS float)  AS BinId FROM tblCat_bin";
            var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

                var sqlQuery = "Insert Into tblCat_bin (BinId, BinName, ComId)" +
                               " Values ('" + NewId + "','" + model.BinName + "',2)";
                arrayList.Add(sqlQuery);
                CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
                return "Success";
            }

        public string BinUpdate(Bin model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();

            var sqlQuery = "Update tblCat_bin set BinName = '" + model.BinName + "' where BinId = '" + model.BinId + "'";
                          
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

        public string BinDelete(int Id)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();

            var sqlQuery = "Delete tblCat_bin where  BinId = '" + Id + "'";
                          
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }
    }
}