using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CommonUtility
{
    /// <summary>
    /// 加密方法的实现
    /// </summary>
    public class Encrypt:IEncrypt
    {
        public byte[] MD5(string pwd)
        {
            byte[] encryptPWD = new ASCIIEncoding().GetBytes(pwd);
            //调用MD5类加密数据
            MD5Cng m = new MD5Cng();
            return m.ComputeHash(encryptPWD);
        }
        
        public byte[] SHA1(string pwd)
        {
            byte[] encryptPWD = new ASCIIEncoding().GetBytes(pwd);
            //调用SHA1类加密数据
            SHA1Managed sha = new SHA1Managed();
            return sha.ComputeHash(encryptPWD);
        }
    }
}
