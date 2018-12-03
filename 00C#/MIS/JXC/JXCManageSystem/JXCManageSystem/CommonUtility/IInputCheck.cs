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
        //管理员密码强度检测
        bool CheckPassWord(string pwd);
    }
}
