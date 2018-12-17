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
    public class BorrowInfo
    {
        private SqlCommand cmd;

        public BorrowInfo()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// 按图书证号查询该读者借书记录
        /// </summary>
        public DataSet GetBorrowInfoByUserID(string userID)
        {
            if (string.IsNullOrEmpty(userID))
                throw new ArgumentNullException("userID");

            cmd.CommandText = "GetBorrowInfoByUserID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userID;
            return DBAccess.QueryData(cmd);
        }

        /// <summary>
        /// 判断是否存在对应图书ID的图书
        /// </summary>
        private bool _HasBook(string bookID)
        {
            if (string.IsNullOrEmpty(bookID))
                throw new ArgumentNullException("bookID");
            cmd.CommandText = "HasThisBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookID;
            object obj = DBAccess.GetScalar(cmd);
            //判断此书的数量大于0，表示有这本书
            if((int)(obj)>0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断对应图书ID的图书是否被借出 
        /// 为true表示可以借，false表示不能借
        /// </summary>
        private bool _CanBorrow(string bookID)
        {
            if (string.IsNullOrEmpty(bookID))
                throw new ArgumentNullException("bookID");
            cmd.CommandText = "IsBorrowed";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookID;
            object obj = DBAccess.GetScalar(cmd);
            if (obj == null)
                //此书从未借过，返回true，此书可以借
                return true;
            else if (Convert.ToBoolean(obj))
                //此书已经归还，返回true，此书可借
                return true;
            else
                //此书未还，不能借
                return false;                 
        }

        /// <summary>
        /// 借书  -1表示没有这本书  0这本书已经借出  1借书成功  9数据访问失败
        /// </summary>
        public int BorrowBook(string bookID,string userID)
        {
            if (string.IsNullOrEmpty(bookID))
                throw new ArgumentNullException("bookID");
            if (string.IsNullOrEmpty(userID))
                throw new ArgumentNullException("userID");
            //判断是否有这本书
            if (!_HasBook(bookID))
                return -1;
            //判断此书是否能借
            if (!_CanBorrow(bookID))
                return 0;
            //借书操作
            cmd.CommandText = "BorrowBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookID", SqlDbType.Char, 15).Value = bookID;
            cmd.Parameters.Add("@UserID", SqlDbType.Char, 11).Value = userID;
            var result = DBAccess.ExecuteSQL(cmd);
            if (result > 0)
                return 1;
            else
                return 9;
        }
    }
}
