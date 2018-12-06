using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using Enity;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;
using CommonUtility;

namespace BusinessLogicLayer
{
   public  class EmployeeBLL:ICRUD<Employee>
    {
       private SqlCommand _cmd;
       public EmployeeBLL()
        {
            _cmd = new SqlCommand();
            _cmd.CommandType = CommandType.StoredProcedure;
        }

       public bool Login(string cardNo,string passWord)
       {
           _cmd.CommandText = "EmployeeLogin";
           _cmd.Parameters.Clear();
           _cmd.Parameters.Add("@CardNo", SqlDbType.NVarChar, 8).Value = cardNo;
           _cmd.Parameters.Add("@Password", SqlDbType.Binary, 50).Value = new Encrypt().SHA1(passWord);
           var result = (int)DBAccess.GetScalar(_cmd);
           if (result > 0)
               return true;
           else
               return false;
       }

        public bool Add(Employee entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");
            _cmd.CommandText = "InsertEmployee";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@CardNo", SqlDbType.NVarChar,8).Value = entity.CardNo;
            _cmd.Parameters.Add("@Password", SqlDbType.Binary,50).Value = entity.PassWord;
            _cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = entity.EmployeeName;
            _cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = entity.Sex;
            _cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = entity.Phone;
            _cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = entity.Memo;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Delete(Employee entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");
            _cmd.CommandText = "DeleteEmployee";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = entity.EmployeeID;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Edit(Employee entity)
        {
            //参数不能为空
            if (entity == null)
                throw new ArgumentNullException("entity");
            _cmd.CommandText = "UpdateEmployee";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = entity.EmployeeID;
            _cmd.Parameters.Add("@CardNo", SqlDbType.NVarChar, 8).Value = entity.CardNo;
            _cmd.Parameters.Add("@Password", SqlDbType.Binary, 50).Value = entity.PassWord;
            _cmd.Parameters.Add("@BaseFunction", SqlDbType.Int).Value = entity.BaseFunction;
            _cmd.Parameters.Add("@PurchaseFunction", SqlDbType.Int).Value = entity.PurchaseFunction;
            _cmd.Parameters.Add("@EmployeeFunction", SqlDbType.Int).Value = entity.EmployeeFunction;
            _cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = entity.EmployeeName;
            _cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = entity.Sex;
            _cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = entity.Phone;
            _cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = entity.Memo;
            var result = DBAccess.ExecuteSQL(_cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        public List<Employee> GetAll()
        {
            _cmd.CommandText = "getallEmployees";
            _cmd.Parameters.Clear();
            var list = new List<Employee>();
            var data = DBAccess.ReadData(_cmd);
            while (data.Read())
            {
                var p = GetDataFromDataReader(data);
                list.Add(p);
            }
            data.Close();
            return list;
        }

        public Employee GetByID(int id)
        {
            _cmd.CommandText = "GetEmployeeByID";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = id;
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

       //按卡号查这名员工
        public Employee GetByCardNo(string cardNo)
        {
            _cmd.CommandText = "GetEmployeeByCardNo";
            _cmd.Parameters.Clear();
            _cmd.Parameters.Add("@CardNo", SqlDbType.NVarChar, 8).Value = cardNo;
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

        private static Employee GetDataFromDataReader(SqlDataReader data)
        {
            var e = new Employee();
            e.EmployeeID =  Convert.ToInt32(data["EmployeeID"]);
            e.EmployeeName = data["EmployeeName"].ToString().Trim();
            e.CardNo = data["CardNo"].ToString().Trim();
            e.PassWord = data["PassWord"] as byte[];
            e.Sex = (bool)data["Sex"];
            e.Phone = data["Phone"].ToString().Trim();
            e.Memo = data["Memo"].ToString().Trim();
            e.BaseFunction = Convert.ToInt32(data["BaseFunction"]);
            e.PurchaseFunction = Convert.ToInt32(data["PurchaseFunction"]);
            e.EmployeeFunction = Convert.ToInt32(data["EmployeeFunction"]);
            return e;
        }
    }
}
