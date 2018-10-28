using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonUtility
{
    /// <summary>
    /// 输入检测的实现
    /// </summary>
    public class InputCheck:IInputCheck
    {
        public bool CheckPassWord(string pwd)
        {
            //要求密码长度为6位以上的字符串
            if (pwd.Length < 6)
                return false;
            else
                return true;
        }
    }
}
