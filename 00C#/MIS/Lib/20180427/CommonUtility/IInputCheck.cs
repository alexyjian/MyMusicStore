using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    /// <summary>
    /// 用于用户输入检测方法的统一接口
    /// </summary>
    public  interface IInputCheck
    {
        //图书ID的输入检测
        bool CheckBookID(string bookID);   

        //ISBN的输入检测
        bool CheckISBN(string isbn);

        //管理员密码强度检测
        bool CheckPassWord(string pwd);
    }
}
