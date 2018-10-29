using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
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
        public static int ExecuteSQL(SqlCommand cmd)
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
                //使用自定义的异常
                throw new DBExption(ex);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }

        /// <summary>
        /// 执行查询结果为记录集的方法
        /// DataSet是C#中暂时保存数据库记录的缓存区域
        /// SqlDataAdapter是数据集与数据库交互的工具
        /// </summary>
        public static DataSet QueryData(SqlCommand cmd)
        {
            var conn = new SqlConnection(connectionString);
            cmd.Connection = conn;
            //查询结果的数据集
            var ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            try
            {
                sda.Fill(ds);
            }
            catch(Exception ex)
            {
                //使用自定义的异常
                throw new DBExption(ex);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return ds;
        }

        /// <summary>
        /// 执行返回单行单列的sql命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static object GetScalar(SqlCommand cmd)
        {
            var conn = new SqlConnection(connectionString);
            cmd.Connection = conn;
            var obj = new object();
            try
            {
                conn.Open();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //使用自定义的异常
                throw new DBExption(ex);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return obj;
        }
    }
}
