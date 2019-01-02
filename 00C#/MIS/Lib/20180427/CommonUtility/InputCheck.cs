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
        #region ISBN检测
        // 获取某位的ISBN字符  
        private static int GetISBNAt(String isbn, int index, bool xEnable)
        {
            char c = Convert.ToChar(isbn.Substring(index, 1));

            int n = c - '0';

            if (n < 0 || n > 9)
            {
                if (xEnable && (c == 'X' || c == 'x'))
                {
                    n = 10;
                }
            }
            return n;
        }

        public bool CheckISBN(string isbn)
        {
            try
            {
                int checkNum = 0;
                if (isbn.Length == 10)
                {
                    int start = 10;
                    int total = 0;
                    for (int i = 0; i < isbn.Length - 1; ++i)
                    {
                        total += GetISBNAt(isbn, i, false) * start--;
                    }
                    checkNum = total % 11;
                    if (checkNum > 0)
                    {
                        checkNum = 11 - checkNum;
                    }
                }
                else
                {
                    int total = 0;
                    for (int i = 0; i < isbn.Length - 1; ++i)
                        total += GetISBNAt(isbn, i, false) * (i % 2 == 0 ? 1 : 3);
                    checkNum = total % 10;
                    if (checkNum > 0)
                        checkNum = 10 - checkNum;
                }
                return GetISBNAt(isbn, isbn.Length - 1, true) == checkNum;
            }
            catch
            {
                return false;
            }  
        }
        #endregion

        public bool CheckBookID(string bookID)
        {
            //要求为15位的纯数字，请大家完成
            //return Regex.IsMatch(bookID, @"^\d{15}$");
            return true;
        }

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
