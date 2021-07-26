#define istrue   //定义一个宏，
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace My_demo04_特性
{
    class Program
    {
        // 该特性表示该方法被弃用（但是还可以被调用），括号里面是提示
        [Obsolete("这个方法过时了，使用NewMethod()这个方法")]
        public static void OldMethod()
        {
            Console.WriteLine("hello word");
        }
        public static void NewMethod()
        {
            Console.WriteLine("hello word01");
        }
        //该特性表示：要想test01被调用，必须定义一个宏在最上面
        [Conditional("istrue")]
        static void Test01()
        {
            Console.WriteLine("test01");
        }
        static void Test02() 
        {
            Console.WriteLine("test02");
        }
        //都是系统传值
        //CallerFilePath 获取文件路径，CallerLineNumber 获取调用的代码行，CallerMemberName获取调用的方法名
        public static void printstr(string str  , [CallerFilePath]string fileName="",[CallerLineNumber]int line=0,[CallerMemberName]string methodName="") 
        {
            Console.WriteLine(str);
            Console.WriteLine(fileName);
            Console.WriteLine(line);
            Console.WriteLine(methodName);
            /*
             * 你好啊
            C:\Users\Administrator\source\repos\My_demo04_特性\Program.cs
            50
            Main

            */
        }

        static void Main(string[] args)
        {
            // OldMethod();
            /*  Test01();
              Test02();
              Test01();*/
            printstr("你好啊");
            Console.ReadKey();
        }
    }
}
