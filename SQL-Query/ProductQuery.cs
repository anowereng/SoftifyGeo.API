using System;
using Sampan;
using System.Data;
using System.Collections;
using System.Linq.Expressions;
using SoftifyGEO.API.Models;
using SoftifyGEO.API.Helpers;
namespace SoftifyGEO.API.SQL_Query
{
    public class ProductQuery
    {
        public static DataSet dsList = new DataSet();
        public string GetProductList()
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            dsList = new DataSet();
            string strQuery = "Exec [prcGet_ProductList] 2";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerialize(dsList.Tables[0]);
        }

         public string GetProduct(int Productid)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            dsList = new DataSet();
            string strQuery = "Exec [prcGet_Product] 0,'"+Productid+"' ";
            dsList = CoreSQL.CoreSQL_GetDataSet(strQuery);
            return clsCommon.JsonSerializeDataSet(dsList);
        }
        public string ProductAdd(Product model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();
            var Query = "SELECT  cast(Isnull(MAX(ProductId),0) + 1 AS float)  AS ProductId FROM tbl_Product";
            var NewId = CoreSQL.CoreSQL_GetDoubleData(Query);

                var sqlQuery = "Insert Into tbl_Product ( SupplierId, ProductId, ProductName, OPQty, SellPrice, UnitId, CostPrice, Currency, Total, LUserId, ComId)" +
                               " Values ('" + model.SupplierId + "','" + NewId + "','" + model.ProductName + "','" + 0 + "','" + model.SellPrice + "', '" + model.UnitId + "','" + model.CostPrice + "','" + model.Currency + "','" + (model.SellPrice * model.CostPrice) + "','" + 2 + "',2)";
                arrayList.Add(sqlQuery);
                CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
                return "Success";
        }

        public string ProductUpdate(Product model)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();

            var sqlQuery = "Update tbl_Product set ProductName = '" + model.ProductName + "', SupplierId='" +
                           model.SupplierId + "', OPQty='" + model.OPQty + "', SellPrice='" + model.SellPrice +
                           "', UnitId='" + model.UnitId + "', CostPrice='" + model.CostPrice +
                           "', Currency='" + model.Currency + "', Total='" + (model.SellPrice * model.CostPrice) + "' where Productid = '" + model.ProductId + "'";
                          
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }

        public string ProductDelete(int Id)
        {
            CoreSQLConnection CoreSQL = new CoreSQLConnection();
            ArrayList arrayList = new ArrayList();

            var sqlQuery = "Delete tbl_Product where  Productid = '" + Id + "'";
                          
            arrayList.Add(sqlQuery);
            CoreSQL.CoreSQL_SaveDataUseSQLCommand(arrayList);
            return "Success";
        }
    }
}