using System;
using System.Collections;
using System.Collections.Generic;

namespace 快乐数
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int num = new Random().Next(0, 100);
            var flag = s.IsHappy(num);
            if (flag)
            {
                Console.WriteLine($"{num}为快乐数");
            }
            else
            {
                Console.WriteLine($"{num}不是快乐数");
            }
        }
    }

    public class Solution
    {
        public bool IsHappy(int n)
        {
            HashSet<int> item = new HashSet<int>();
            while (item.Add(n))
            {
               n = GetNum(n);
                if (n == 1) return true;
            }

            return false;
        }
        public int GetNum(int n) 
        {
            var totalnum = 0;
            while (n>0)
            {
                var d = n % 10;
                    n /= 10;
                totalnum += d * d;
            }
            return totalnum;
        }
    }

}
