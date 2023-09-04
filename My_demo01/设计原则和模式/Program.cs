using System;
using 设计原则和模式.开闭原则;

namespace 设计原则和模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICourse csCourse = new CSharpCourse("CS", "123", 10);

            Console.WriteLine("名字: "+ csCourse.GetName());
            Console.WriteLine("ID: "+ csCourse.GetID());
            Console.WriteLine("价格: "+ csCourse.GetPrice());

            ICourse daZheCsCourse = new DaZheCSharpCourse("CS", "123", 10);
            var daZhe = daZheCsCourse as DaZheCSharpCourse;
            Console.WriteLine("原价: " + daZhe.GetPrice());
            Console.WriteLine("打折后价格: " + daZhe.GetDaZhePrice(0.5));

        }
    }
}
