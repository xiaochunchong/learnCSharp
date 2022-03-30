using System;
using System.Collections.Generic;

namespace 罗马数字转整数
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution so = new Solution();
            var re = so.RomanToInt("MCMXCIV");
            Console.WriteLine(re);
        }
    }

    public class Solution
    {
        Dictionary<char, int> symbolValues = new Dictionary<char, int> 
        {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}, };

        public int RomanToInt(string s)  //MCMXCIV
        {
            int ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //注意值的范围（判断到倒数第二位就可以了）
                if ( i<s.Length-1 && symbolValues[s[i]] < symbolValues[s[i+1]])
                {
                    ans = ans - symbolValues[s[i]];
                }
                else
                {
                    ans = ans + symbolValues[s[i]];
                }
            }
            return ans;
        }
    }
}
