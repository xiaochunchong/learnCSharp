using System;

namespace 泰波那契数列
{
   public class Program
    {
        static void Main(string[] args)
        {
           var re = Tribonacci(35);
            Console.WriteLine(re);
            Console.ReadKey();
        }
        public static  int Tribonacci(int n)
        {
            if (n <= 2)
            {
                return n == 0 ? 0 : 1;
            }
            int[] aa = new int[n+1];
            aa[0] = 0;
            aa[1] = 1;
            aa[2] = 1;
            for (int i = 3; i <= n; i++)
            {
                aa[i] = aa[i - 1] + aa[i - 2] + aa[i - 3];
            }
            return aa[n];
        }
    }
}
