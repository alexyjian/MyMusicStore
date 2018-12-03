using Enity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ProductBLL:ICRUD<Product>
    {
        private SqlCommand _cmd;
        public ProductBLL()
        {
            _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
        }
        public List<Product> GetAll()
        {
            _cmd.CommandText = "getallproducts";
            _cmd.Parameters.Clear();
            var list = new List<Product>();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                var p = GetDataFromDataReader(data);
                list.Add(p);
            }
            data.Close();
            return list;
        }
        private static Product GetDataFromDataReader(SqlDataReader data)
        {
            var p = new Product();
            p.ProductID = data["ProductID"].ToString().Trim();
            p.ProductName = data["ProductName"].ToString().Trim();
            p.SpellCode = data["SpellCode"].ToString().Trim();
            p.BarCode = data["BarCode"].ToString().Trim();
            p.Special = data["Special"].ToString().Trim();
            p.Unit = data["Unit"].ToString().Trim();
            p.Original = data["Original"].ToString().Trim();
            p.PurchasePrice = Convert.ToDecimal(data["PurchasePrice"]);
            p.Quantity = Convert.ToInt32(data["Quantity"]);
            p.CategoryID = Convert.ToInt32(data["CategoryID"]);
            //由于此字段在数据库中并没有，所以需要调用分类查询方法来查出来
            p.CategoryName = new CategoryBLL().GetByID(p.CategoryID).CategoryName;  
            return p;
        }

        public bool Add(Product entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");
            _cmd.CommandText = "InsertProduct";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = entity.ProductName;
            _cmd.Parameters.Add("@SpellCode", SqlDbType.NVarChar).Value = entity.SpellCode;
            _cmd.Parameters.Add("@BarCode", SqlDbType.NVarChar).Value = entity.BarCode;
            _cmd.Parameters.Add("@Special", SqlDbType.NVarChar).Value = entity.Special;
            _cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = entity.Unit;
            _cmd.Parameters.Add("@Original", SqlDbType.NVarChar).Value = entity.Original;
            _cmd.Parameters.Add("@PurchasePrice", SqlDbType.Decimal).Value = entity.PurchasePrice;
            _cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = entity.Quantity;
            _cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = entity.CategoryID;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Delete(Product entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");
            _cmd.CommandText = "DeleteProduct";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = entity.ProductID;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Edit(Product entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");
            _cmd.CommandText = "UpdateProduct";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = entity.ProductName;
            _cmd.Parameters.Add("@SpellCode", SqlDbType.NVarChar).Value = entity.SpellCode;
            _cmd.Parameters.Add("@BarCode", SqlDbType.NVarChar).Value = entity.BarCode;
            _cmd.Parameters.Add("@Special", SqlDbType.NVarChar).Value = entity.Special;
            _cmd.Parameters.Add("@Unit", SqlDbType.NVarChar).Value = entity.Unit;
            _cmd.Parameters.Add("@Original", SqlDbType.NVarChar).Value = entity.Original;
            _cmd.Parameters.Add("@PurchasePrice", SqlDbType.Decimal).Value = entity.PurchasePrice;
            _cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = entity.Quantity;
            _cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = entity.CategoryID;
            _cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = entity.ProductID;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }


        public Product GetByID(int id)
        {
            _cmd.CommandText = "GetProductByID";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            var data = DBAccess.ReadData(_cmd);
            if (data.Read())
            {
                var p = GetDataFromDataReader(data);
                data.Close();
                return p;
            }
            else
            {
                data.Close();
                return null;
            }
        }
    }
}
