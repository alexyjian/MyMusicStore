using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MusicStore
{
    /// <summary>
    /// 支付宝sdk，自写版本，使用后果自负
    /// </summary>
    public class AlipayHelper
    {
        public static bool VerifyParameter(string key, NameValueCollection collection)
        {
            string sign = collection["sign"];
            if (string.IsNullOrEmpty(sign))
                return false;
            if (SignParameter(key, GetParameter(collection)) != sign)
                return false;
            return true;
        }

        public static async Task<bool> VerifyNotify(string partner, string notifyId)
        {
            string url = "https://mapi.alipay.com/gateway.do?service=notify_verify&" + "partner=" + partner +
                         "&notify_id=" + notifyId;
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            request.Timeout = 12000;
            try
            {
                HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string result = await reader.ReadToEndAsync();
                reader.Close();
                stream.Close();
                response.Dispose();
                return result == "true";
            }
            catch
            {
                return false;
            }
        }

        public static IEnumerable<KeyValuePair<string, string>> GetParameter(NameValueCollection collection)
        {
            return collection.Keys.OfType<string>().ToDictionary(t => t, t => collection[t]);
        }

        public static string SignParameter(string key, IEnumerable<KeyValuePair<string, string>> values)
        {
            values = SortParameter(FilterParameter(values));

            string value = string.Join("&", values.Select(t => t.Key + "=" + t.Value)) + key;

            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] s = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            string sign = new string(s.SelectMany(t => t.ToString("x").PadLeft(2, '0')).ToArray());
            return sign;
        }

        public static IEnumerable<KeyValuePair<string, string>> FilterParameter(
            IEnumerable<KeyValuePair<string, string>> values)
        {
            return
                values.Where(
                    t =>
                        t.Key != "sign" && t.Key != "sign_type" && t.Key != "returnUrl" &&
                        !string.IsNullOrEmpty(t.Value));
        }

        public static IEnumerable<KeyValuePair<string, string>> SortParameter(
            IEnumerable<KeyValuePair<string, string>> values)
        {
            return values.OrderBy(t => t.Key);
        }
    }
}