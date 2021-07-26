using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



/// <summary>
/// 反射 和 特性
///  Type类
/// </summary>
namespace My_demo02
{
    class Program
    {
        static void Main(string[] args)
        {
            //每一个类对应一个type对象，这个对象存储了这个类的 哪些方法和 哪些成员信息
            Myclass mc = new Myclass();
            //使用对象my的GetType()方法返回一个type对象（mc所属类的Type对象）
            Type type = mc.GetType();//type只存储该类成员信息，不存储该类成员的赋值
            Console.WriteLine(type.Name);  //获取类名
            Console.WriteLine(type.Assembly); //获取该类的程序集

            FieldInfo[] fieids = type.GetFields();//获取字段信息(只能获取共有public字段)
            PropertyInfo[] propertys = type.GetProperties(); // 获取属性  
            MethodInfo[] methods = type.GetMethods();//获取所有方法名

            Assembly assem = type.Assembly;  //获取所在程序集Assembly
            Console.WriteLine("\n"+assem.FullName+"01");
            
          Type[] types =   assem.GetTypes(); //当前程序集下所有的(类)类型（myclass 和 program）

            // HttpClient ht = new HttpClient();

            Console.ReadKey();




        }
    }
}
