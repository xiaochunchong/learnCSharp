using System;

namespace My_demo10_委托_匿名函数_lambda
{
    class Program
    {
        public delegate int Mydelegate(int a, int b);
        static void Main(string[] args)
        {
            // 1、委托的原始使用方式

            /*Mydelegate de = new Mydelegate(method01);
            var re = de(3, 4);
            Console.WriteLine(re);
            Console.ReadKey();*/


            //2、匿名方法 ,没有方法名，只有方法体
            /*
                        Mydelegate de1 = delegate(int a, int b)  // delegate是关键字
                         {
                             return a * b;
                         };
                        Console.WriteLine(de1(2,2));
                        Console.ReadKey();
            */

            //3、lambda表达式  , 符号 " => "
            /*
                        Mydelegate de1 = (int a, int b)  =>
                        {
                            return a * b;
                        };
                        Console.WriteLine(de1(4, 2));
                        Console.ReadKey();
            */
            // 4、泛型func ,不用声明委托变量，直接用
            Func<int, int, int> f1 = ( a , b) =>
             {
                 return a / b;
             };

            Console.WriteLine(f1(9, 3));
            Console.ReadKey();

            Action<int, int> f2 = (a, b) =>
            {
                Console.WriteLine(a*b);
                Console.ReadKey();
            };
        }
        public static int method01(int a, int b ) 
        {
            return a + b;
        }
    }
}
