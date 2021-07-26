using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace My_demo06调用外部API
{
    //调用外部（百度翻译）API ，GET方式
    class Program
    {
        // 计算MD5值
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            string reading = Console.ReadLine();
            //传输的各种参数
            string appid = "20201020000594778";
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            string secretKey = "Pc_jj3MCeaSfE1cYmMY8";
            //拼接字符，md5加密
            string sign = EncryptString(appid + reading + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
            url += "q=" +reading;
            url += "&from=zh";
            url += "&to=en";
            url += "&appid=" + appid;
            url += "&salt=" + salt;
            url += "&sign=" + sign;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 6000;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            { 
            Stream resp = response.GetResponseStream();
            StreamReader read = new StreamReader(resp, Encoding.GetEncoding("utf-8"));
            var result = read.ReadToEnd();
            var a = Regex.Unescape(result);
             read.Close();
             resp.Close();
                response.Dispose();
            Console.WriteLine(a);
            Console.ReadLine();
            }
        }
    }
}
