using System;

namespace 采用递归求第n位数_斐波那契_
{
    /// <summary>
    /// 一个数列，第n个数等于前两数之和 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            //  int a = NumAdd(m);
            var a = Tribonacci(m);
            Console.WriteLine(a);
            Console.ReadKey();
        }
        public static int NumAdd(int a)
        {
            if (a == 0) return 0;
            else if (a == 1) return 1;   // 1,1,2,3,5,8,13,21,34
            else
            {
                return NumAdd(a - 1) + NumAdd(a - 2);
            }
        }

        public static  int Tribonacci(int n)
        {
            var re = NumAdd1(n);
            return re;
        }
        public static int NumAdd1(int a)
        {
            if (a == 0) return 0;
            else if (a == 1) return 1;
            else if (a == 2) return 1;
            else
            {
                return NumAdd(a - 1) + NumAdd(a - 2) + NumAdd(a - 3);
            }
        }
    }
}
