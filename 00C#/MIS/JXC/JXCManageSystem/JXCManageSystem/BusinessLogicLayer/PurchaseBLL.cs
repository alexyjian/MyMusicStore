using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enity;
using DataAccessLayer;
using BusinessLogicLayer;
using System.Data.SqlClient;
using System.Data;


namespace BusinessLogicLayer
{
    public class PurchaseBLL:ICRUD<Purchase>
    {
         private SqlCommand _cmd;
         public PurchaseBLL()
        {
            _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
        }

        //按流水号查询相应入库申请的信息
        public Purchase GetPurchaseBySerialNumber(string sn)
         {
             _cmd.CommandText = "GetPurchaseBySerialNumber";
             _cmd.Parameters.Clear();
             _cmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar, 12).Value = sn;
             Purchase p = new Purchase();
             SqlDataReader sdr = DBAccess.ReadData(_cmd);
             while (sdr.Read())
             {
                 p = GetDataFromDataReader(sdr);
             }
             sdr.Close();
             return p;
         }

        private static Purchase GetDataFromDataReader(SqlDataReader sdr)
        {
            var p = new Purchase();
            p.PurchaseID = Convert.ToInt32(sdr["PurchaseID"]);
            p.Serialnumber = sdr["Serialnumber"].ToString();
            p.Memo = sdr["Memo"].ToString();
            p.Clerk = sdr["Clerk"].ToString();
            p.PurchaseDate = Convert.ToDateTime(sdr["PurchaseDate"]);
            p.Examiner = sdr["Examiner"].ToString();
            //判断sql中的NULL, C#用Convert.DBNull表示数据空
            if (sdr["ExaminerDate"]!=Convert.DBNull)
                p.ExaminerDate = Convert.ToDateTime(sdr["ExaminerDate"]);
            p.Custodian = sdr["Custodian"].ToString();
            if (sdr["StockDate"] != Convert.DBNull)
                p.StockDate = Convert.ToDateTime(sdr["StockDate"]);
            p.OnProcess = Convert.ToInt32(sdr["OnProcess"]);
            p.SupplierID = Convert.ToInt32(sdr["SupplierID"]);
            return p;
        }

        //按条件查询对应的流水号集合
        public List<string> GetSerialnumbers(string keyword, DateTime beginDate,DateTime endDate)
         {
             _cmd.CommandText = "GetSerialnumbers";
             _cmd.Parameters.Clear();
             _cmd.Parameters.Add("@keyword", SqlDbType.NVarChar, 12).Value = keyword;
             _cmd.Parameters.Add("@beginDate", SqlDbType.DateTime).Value = beginDate;
             _cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;

             var list = new List<string>();
             SqlDataReader sdr = DBAccess.ReadData(_cmd);
            while(sdr.Read())
            {
                string sn = sdr["Serialnumber"].ToString();
                list.Add(sn);
            }

            sdr.Close();
            return list;
         }

        //按业务员查询对应的流水号集合
        public List<string> GetSerialnumbersByClerk(string clerk, DateTime beginDate, DateTime endDate)
        {
            _cmd.CommandText = "GetSerialnumbersByClerk";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@clerk", SqlDbType.NVarChar, 12).Value = clerk;
            _cmd.Parameters.Add("@beginDate", SqlDbType.DateTime).Value = beginDate;
            _cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            var list = new List<string>();
            SqlDataReader sdr = DBAccess.ReadData(_cmd);
            while (sdr.Read())
            {
                string sn = sdr["Serialnumber"].ToString();
                list.Add(sn);
            }
            sdr.Close();
            return list;
        }

        //按主管查询对应的流水号集合
        public List<string> GetSerialnumbersByExaminer(string examiner, DateTime beginDate, DateTime endDate)
        {
            _cmd.CommandText = "GetSerialnumbersByexaminer";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@Examiner", SqlDbType.NVarChar, 12).Value = examiner;
            _cmd.Parameters.Add("@beginDate", SqlDbType.DateTime).Value = beginDate;
            _cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            var list = new List<string>();
            SqlDataReader sdr = DBAccess.ReadData(_cmd);
            while (sdr.Read())
            {
                string sn = sdr["Serialnumber"].ToString();
                list.Add(sn);
            }
            sdr.Close();
            return list;
        }

        //按状态查询对应的流水号集合
        public List<string> GetSerialnumbersByProcess(int process, DateTime beginDate, DateTime endDate)
        {
            _cmd.CommandText = "GetSerialnumbersByProcess";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@Process", SqlDbType.Int).Value = process;
            _cmd.Parameters.Add("@beginDate", SqlDbType.DateTime).Value = beginDate;
            _cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;
            var list = new List<string>();
            SqlDataReader sdr = DBAccess.ReadData(_cmd);
            while (sdr.Read())
            {
                string sn = sdr["Serialnumber"].ToString();
                list.Add(sn);
            }
            sdr.Close();
            return list;
        }

        //按流水号查询商品明细
        public List<PurchaseDetail> GetPurchaseDetails(string sn)
        {
            _cmd.CommandText = "GetPurchaseDetailsBySerialNumber";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar,12).Value = sn;

            var list = new List<PurchaseDetail>();
            SqlDataReader sdr = DBAccess.ReadData(_cmd);
            while (sdr.Read())
            {
                var d = new PurchaseDetail();
                d.BarCode = sdr["BarCode"].ToString();
                d.Price = Convert.ToDecimal(sdr["Price"]);
                d.ProductID = Convert.ToInt32(sdr["ProductID"]);
                d.ProductName = sdr["ProductName"].ToString();
                d.PurchaseDetailID = Convert.ToInt32(sdr["PurchaseDetailID"]);
                d.PurchaseID = Convert.ToInt32(sdr["PurchaseID"]);
                d.Quantity = Convert.ToInt32(sdr["Quantity"]);
                d.Serialnumber = sdr["Serialnumber"].ToString();
                d.SortCode = Convert.ToInt32(sdr["SortCode"]);
                list.Add(d);
            }
            sdr.Close();
            return list;
        }

        public Purchase Add(Purchase entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _cmd.CommandText = "InsertPurchase";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@memo", SqlDbType.NVarChar).Value = entity.Memo;
            _cmd.Parameters.Add("@supplierID", SqlDbType.Int).Value = entity.SupplierID;
            _cmd.Parameters.Add("@clerk", SqlDbType.NVarChar,12).Value = entity.Clerk;
            //配置输出参数
            _cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            _cmd.Parameters.Add("@sn", SqlDbType.NVarChar,12).Direction = ParameterDirection.Output;

            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
            {
                entity.PurchaseID = (int)_cmd.Parameters["@id"].Value;
                entity.Serialnumber = _cmd.Parameters["@sn"].Value.ToString();
                return entity;
            }
            else
                return null;
        }

        public bool Delete(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Purchase entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _cmd.CommandText = "UpdatePurchase";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@memo", SqlDbType.NVarChar).Value = entity.Memo;
            _cmd.Parameters.Add("@supplierID", SqlDbType.Int).Value = entity.SupplierID;
            _cmd.Parameters.Add("@purchaseid", SqlDbType.Int).Value = entity.PurchaseID;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool EditExamandStock(Purchase entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _cmd.CommandText = "UpdateExamStockPurchase";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@memo", SqlDbType.NVarChar).Value = entity.Memo;
            _cmd.Parameters.Add("@supplierID", SqlDbType.Int).Value = entity.SupplierID;
            _cmd.Parameters.Add("@clerk", SqlDbType.NVarChar,8).Value = entity.Clerk;
            _cmd.Parameters.Add("@purchasedate", SqlDbType.DateTime).Value = entity.PurchaseDate;
            _cmd.Parameters.Add("@examiner", SqlDbType.NVarChar, 8).Value = entity.Examiner;
            _cmd.Parameters.Add("@examinerdate", SqlDbType.DateTime).Value = string.IsNullOrEmpty(entity.Examiner) ? Convert.DBNull : entity.ExaminerDate; 
            _cmd.Parameters.Add("@Custodian", SqlDbType.NVarChar, 8).Value = entity.Custodian;
            _cmd.Parameters.Add("@StockDate", SqlDbType.DateTime).Value =string.IsNullOrEmpty(entity.Custodian)?Convert.DBNull:entity.StockDate;
            _cmd.Parameters.Add("@onprocess", SqlDbType.Int).Value = entity.OnProcess;
            _cmd.Parameters.Add("@purchaseid", SqlDbType.Int).Value = entity.PurchaseID;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }
        

        public List<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Purchase GetByID(int id)
        {
            throw new NotImplementedException();
        }
        bool ICRUD<Purchase>.Add(Purchase entity)
        {
            throw new NotImplementedException();
        }

        //添加入库明细
        public bool AddDetail(PurchaseDetail detail)
        {
            if (detail == null)
                throw new ArgumentNullException("detail");

            _cmd.CommandText = "InsertPurchaseDetail";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@purchaseid", SqlDbType.Int).Value = detail.PurchaseID;
            _cmd.Parameters.Add("@productid", SqlDbType.Int).Value = detail.ProductID;
            _cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = detail.Price;
            _cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = detail.Quantity;
            _cmd.Parameters.Add("@sortcode", SqlDbType.Int).Value = detail.SortCode;

            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        //删除该申请中所有明细
        public bool DeleteDetails(int purchaseID)
        {
            _cmd.CommandText = "DeletePurchaseDetail";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@purchaseid", SqlDbType.Int).Value = purchaseID;

            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
