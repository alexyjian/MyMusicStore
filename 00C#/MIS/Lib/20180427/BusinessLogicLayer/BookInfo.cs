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
    /// <summary>
    /// 图书信息管理业务逻辑
    /// </summary>
    public class BookInfo
    {
        private SqlCommand cmd;

        public BookInfo()
        {
            cmd = new SqlCommand();
            //指定SQL命令为执行存储过程
            cmd.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="bookId">图书编号</param>
        /// <returns></returns>
        public bool DeteleBook(string bookId)
        {
            return false;
        }

        /// <summary>
        /// 查询图书信息
        /// </summary>
        /// <param name="bookName">书名</param>
        /// <param name="classId">分类</param>
        /// <returns></returns>
        public DataSet GetBookInfo(string bookName,string classId)
        {
            //赋值要执行的存储过程命令
            cmd.CommandText = "GetBookInfoByCondition";
            //清除可能存在的旧参数
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ISBN", SqlDbType.Char, 20).Value = "";
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 50).Value = bookName.Trim();
            cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 40).Value = "";
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 10).Value = classId.Trim();

            var ds = new DataSet();
            ds = DBAccess.QueryData(cmd);
            if (ds == null)
                throw new NoRecordException();
            else
                return ds;
        }

        /// <summary>
        /// 查询所有图书类别
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllBookClass()
        {
            cmd.CommandText = "GetAllBookClass";
            return DBAccess.QueryData(cmd);
        }

        /// <summary>
        /// 添加新图书
        /// </summary>
        public bool InsertNewBook(string bookID,string isbn,string bookName,string author,DateTime publishDate,string bookVersion,int wordCount,
            int pageCount,string publisher,string classID)
        {
            //校验用户输入 
            if (string.IsNullOrEmpty(bookID))
                throw new ArgumentNullException("bookID");
            if (string.IsNullOrEmpty(bookName))
                throw new ArgumentNullException("bookName");
            if (string.IsNullOrEmpty(classID))
                throw new ArgumentNullException("classID");

            //存储过程初始化
            cmd.CommandText = "InsertNewBook";
            cmd.Parameters.Clear();

            //定义参数数组对存储过程参数进行赋值
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@BookID",bookID),
                new SqlParameter("@ISBN",isbn),
                new SqlParameter("@BookName",bookName),
                new SqlParameter("@Author",author),
                new SqlParameter("@PublishDate",publishDate),
                new SqlParameter("@BookVersion",bookVersion),
                new SqlParameter("@WordCount",wordCount),
                new SqlParameter("@PageCount",pageCount),
                new SqlParameter("@Publisher",publisher),
                new SqlParameter("@ClassID",classID),
            };
            cmd.Parameters.AddRange(parms);

            var result = DBAccess.ExecuteSQL(cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新图书
        /// </summary>
        public bool UpdateBook(string bookID,string isbn,string bookName,string author,
            DateTime publishDate,string bookVersion,int wordCount,int pageCount,string publisher,string classID)
        {
            //校验用户输入 
            if (string.IsNullOrEmpty(bookName))
                throw new ArgumentNullException("bookName");
            if (string.IsNullOrEmpty(classID))
                throw new ArgumentNullException("classID");

            //存储过程初始化
            cmd.CommandText = "UpdateBookInfo";
            cmd.Parameters.Clear();

            //定义参数数组对存储过程参数进行赋值
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@BookID",bookID),
                new SqlParameter("@ISBN",isbn),
                new SqlParameter("@BookName",bookName),
                new SqlParameter("@Author",author),
                new SqlParameter("@PublishDate",publishDate),
                new SqlParameter("@BookVersion",bookVersion),
                new SqlParameter("@WordCount",wordCount),
                new SqlParameter("@PageCount",pageCount),
                new SqlParameter("@Publisher",publisher),
                new SqlParameter("@ClassID",classID),
            };
            cmd.Parameters.AddRange(parms);

            var result = DBAccess.ExecuteSQL(cmd);
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除图书
        /// </summary>
        public bool DeleteBook(string bookId)
        {
            //检查参数 不能为空或空字符串
            if (string.IsNullOrEmpty(bookId))
                throw new ArgumentNullException("bookId");
            //执行存储过程
            cmd.CommandText = "DeleteBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 15).Value = bookId;
            //返回受影响的行数
            var result = DBAccess.ExecuteSQL(cmd);
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
