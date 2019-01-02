using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    /// <summary>
    /// 加密类的接口
    /// </summary>
    public interface IEncrypt
    {
        //MD5加密
        byte[] MD5(string pwd);
        //SHA1加密
        byte[] SHA1(string pwd);
    }
}
