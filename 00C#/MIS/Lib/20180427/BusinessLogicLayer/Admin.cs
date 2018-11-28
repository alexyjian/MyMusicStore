using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogicLayer
{
    public class Admin
    {
        private SqlCommand cmd;

        public Admin()
        {
            cmd = new SqlCommand();
            //指定SQL命令为执行存储过程
            cmd.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool Login(string adminId,string passWord)
        {
            return false;
        }
    }
}
