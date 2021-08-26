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
    /*
      1-- exe/dll文件的主要区别：exe文件有入口(exe文件有Main函数,dll文件没有)
      2-- metadata元数据：描述exe/dll文件的一个数据清单(例如exe/dll文件拥有哪些类，属性以及方法等...)
      3-- 反射是什么？ 反射就是用来获取和操作metadata元数据的一个类库
   */
    class Program
    {
        static void Main(string[] args)
        {
            //--1-- 
            //通过反射加载程序集
            //Assembly a = Assembly.Load("Infrastructure");
            Assembly assembly = Assembly.LoadFile(@"C:\Users\Administrator\source\repos\My_demo01\Infrastructure\bin\Debug\netstandard2.0\Infrastructure.dll");
            var rr = assembly.GetTypes();
            //var cc = a.GetTypes();

            //--2--
            //每一个类对应一个type对象，这个对象存储了这个类的方法和成员信息
            Myclass mc = new Myclass();
            mc.Name = "sss";
            //使用对象mc的GetType()方法返回一个type对象
            Type type = mc.GetType();//type只存储该类成员信息，不存储该类成员的赋值
            Console.WriteLine(type.Name);  //获取类名
            Console.WriteLine(type.Assembly); //获取该类的程序集
            FieldInfo[] fieids = type.GetFields();//获取字段信息(只能获取共有public字段)
            PropertyInfo[] propertys = type.GetProperties(); // 获取属性  
            MethodInfo[] methods = type.GetMethods();//获取所有方法名
            Assembly assem = type.Assembly;  //获取所在程序集Assembly
            Console.WriteLine("\n"+assem.FullName+"01");       
            Type[] types = assem.GetTypes(); //当前程序集下所有的(类)类型
            //type类型转回原对象类型,（不会保留原来对象的值，相当于使用反射创建新对象 ：Activator.CreateInstance(Type.GetType("命名空间.类名"))）
            var aa = (Myclass)Activator.CreateInstance(type);

            //--3--
            //通过反射创建对象 （方式二：或者可以通过类名获取类的类型，需要带上名字空间   Type tp = Type.GetType("My_demo02.Myclass"); ）
            Assembly a1 = Assembly.GetExecutingAssembly(); // 获取当前程序集  
            Myclass obj = (Myclass)a1.CreateInstance("My_demo02.Myclass"); // 创建类的实例，返回为object类型，需要强制类型转换(类的完全限定名,即包括命名空间)
            obj.Name = "张三"; 
            obj.number = 123456;
           
            //--4--
            //通过反射操作对象, 例如：要把obj对象的字段值赋予ee对象
            Type inf = obj.GetType();
            //Myclass ee = new Myclass(); var tt = ee.GetType();
            Type info = typeof(Myclass);
            PropertyInfo[] pps0 = inf.GetProperties();
            PropertyInfo[] pps1 = info.GetProperties();
            //字段多的时候，可以通过循环来赋值
            foreach (PropertyInfo it in pps0)
            {
                foreach (PropertyInfo pi in pps1)
                {
                    if (it.Name == pi.Name)
                    {
                        info.GetProperty(pi.Name).SetValue(info, it.GetValue(obj));
                    }
                }
            }
        }
    }
}
