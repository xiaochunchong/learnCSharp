using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
namespace ConsoleApp1
{
    class Program
    {
        public static HtmlNode re { get; set; }
        public static void setchild(HtmlNode node, string before, string after)
        {
            foreach (var item in node.ChildNodes)   //判断标签下面是否有标签嵌套着子标签，例如 <p><strong>123</strong>></p>
            {
                if (item.HasChildNodes == true)
                {
                    setchild(item, before, after); //递归处理每个标签下面的子标签
                }
                else    //如果标签下面没有标签了，就进行替换文本信息。注意：HtmlNode是全局变量
                {
                    item.InnerHtml = item.InnerHtml.Replace(before, after);
                }
            }
        }
        static void Main(string[] args)
        {
            string before = "对于";
            string after = "888888";
            string htmlstr = "<p>对于 Netscape 6.2 中 abbr 和 acronym 元素都有效（&nbsp;&nbsp;&nbsp;&nbsp;）。</p>";
            HtmlDocument hd = new HtmlDocument(); //新建该类用于接受html字符信息
            re = hd.CreateElement("");  //hd.CreateElement()返回HtmlNode对象（全局变量re）
            re.InnerHtml = htmlstr;     //HtmlNode对象InnerHtml属性来接收html字符串
            if (re.HasChildNodes == true)  //判断HtmlNode对象里面有没有标签，例如 <p></p>
            {
                setchild(re, before, after);   //调用处理方法，传入HtmlNode对象
            }
            Console.WriteLine(GetKeyName(htmlstr));
            Console.WriteLine(before + "替换成：" + after);
            Console.WriteLine(GetKeyName(re.InnerHtml));
            Console.ReadLine();
        }
        public static string GetKeyName(string value)    //去除html标签
        {
            System.Text.RegularExpressions.Regex objRegExp = new System.Text.RegularExpressions.Regex("<(.|\n)+?>");
            string strOutput = objRegExp.Replace(value, "");
            strOutput = strOutput.Replace("&nbsp;", " ");
            return strOutput;
        }
    }
}