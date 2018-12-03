using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAUtility
{
    /// <summary>
    /// 公共数据访问方法
    /// </summary>
    public class DBAccess
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ToString();

        /// <summary>
        /// 执行增删改等返回受影响行数的公共方法
        /// </summary>
        public static int ExeSQL(SqlCommand cmd)
        {
            var conn = new SqlConnection(connectionString);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                var result = cmd.ExecuteNonQuery();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// 执行查询结果为记录集的方法
        /// </summary>
        public DataSet QueryData(SqlCommand cmd)
        {

        }
    }
}
