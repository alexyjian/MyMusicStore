using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//引用数据处理的类库
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class User
    {
        private SqlCommand cmd;

        public User()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// 查询某个读者的信息
        /// </summary>
        public DataSet GetOneUserInfo(string userID)
        {
            if (string.IsNullOrEmpty(userID))
                throw new ArgumentNullException("userID");

            cmd.CommandText = "GetUserByID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userID;
            return DBAccess.QueryData(cmd);
        }

        /// <summary>
        /// 添加新读者，包含大头像
        /// </summary>
        public bool AddUser(string userID,string userName,string pwd, int sex,string email,string className,byte[] photo)
        {
            //检测必填的参数
            if (string.IsNullOrEmpty(userID) ||
                string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(pwd) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(className))
                throw new ArgumentNullException();

            cmd.CommandText = "InsertNewUserWithPhoto";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userID;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = userName;
            cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar, 10).Value = pwd;
            cmd.Parameters.Add("@Sex", SqlDbType.Bit).Value = sex;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 30).Value = email;
            cmd.Parameters.Add("@Class", SqlDbType.NVarChar, 40).Value = className;
            cmd.Parameters.Add("@image", SqlDbType.Image).Value = photo;

            var result = DBAccess.ExecuteSQL(cmd);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
