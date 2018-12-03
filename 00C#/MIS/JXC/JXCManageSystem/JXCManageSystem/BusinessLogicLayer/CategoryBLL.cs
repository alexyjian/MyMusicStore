using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enity;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CategoryBLL:ICRUD<Category>
    {
        private SqlCommand _cmd;
        public CategoryBLL()
        {
            _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
        }

        public bool Add(Category entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");

            _cmd.CommandText = "InsertCategory";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = entity.CategoryName;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Delete(Category entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");

            _cmd.CommandText = "DeleteCategory";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = entity.CategoryID;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Edit(Category entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");

            _cmd.CommandText = "UpdateCategory";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = entity.CategoryID;
            _cmd.Parameters.Add("@CategoryName", SqlDbType.NVarChar).Value = entity.CategoryName;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public List<Category> GetAll()
        {
            _cmd.CommandText = "GetAllCategories";
            _cmd.Parameters.Clear();
            var list = new List<Category>();
            //读取数据转换为List<Category>
            var data = DBAccess.ReadData(_cmd);
            while(data.Read())
            {
                var id = Convert.ToInt32(data["CategoryID"]);
                var name = data["CategoryName"].ToString();
                var categoryItem = new Category(id, name);
                list.Add(categoryItem);
            }
            data.Close();
            return list;
        }

        public Category GetByID(int id)
        {
            _cmd.CommandText = "GetCategoriesByID";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = id;
            //读取数据转换为List<Category>
            var data = DBAccess.ReadData(_cmd);
            if (data.Read())
            {
                var categoryid = Convert.ToInt32(data["CategoryID"]);
                var name = data["CategoryName"].ToString();
                var categoryItem = new Category(categoryid, name);
                data.Close();
                return categoryItem;
            }
            else
            {
                data.Close();
                return null;
            }
        }
    }
}
