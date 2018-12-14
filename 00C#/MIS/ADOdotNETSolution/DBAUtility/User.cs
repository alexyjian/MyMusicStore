using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAUtility
{
    public class User
    {
        private SqlCommand cmd;

        public User()
        {
            cmd = new SqlCommand();
        }

        /// <summary>
        /// 添加读者
        /// </summary>
        public bool AddUser(string userID,string userName,string pwd, int sex, 
            string email,string className)
        {
            //检测不允许为空的字段
            if(string.IsNullOrEmpty(userID))
                throw new ArgumentNullException("userid");
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(pwd))
                throw new ArgumentNullException("pwd");
            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className");

            var sqlString = "insert tbl_user values('"+userID+"','"+userName+"',"
                +sex+",'"+pwd+"','"+email+"','"+className+"',null)";
            cmd.CommandText = sqlString;
            var result = DBAccess.ExeSQL(cmd);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
