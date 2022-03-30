using System;

namespace 回文数
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution.IsPalindrome(3);
            Console.WriteLine("Hello World!");
        }

    }


    public class Solution
    {
        public  static bool IsPalindrome(int x)
        {
            if (x==0)
            {
                return true;
            }
            if (x<0)
            {
                return false;
            }


            return false;
        }
    }
}
