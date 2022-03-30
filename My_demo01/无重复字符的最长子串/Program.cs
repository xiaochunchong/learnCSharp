using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace 无重复字符的最长子串
{
    /// <summary>
    /// 该题算法：滑动窗口算法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var str = "Hello World!";
            Console.WriteLine(str[0]);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int left = 0 , right = 0; //定义滑动窗口的左右索引
            int windowmaxlenght = 0;  //记录窗口的最大长度
            HashSet<char> set = new HashSet<char>();//定义一个hashset,存放窗口所滑动的数据，hashset里面不能存放重复元素

            while (left<s.Length && right<s.Length)
            {
                if (set.Contains(s[right]))
                {
                    set.Remove(s[left]);
                    left++;
                }
                else
                {
                    set.Add(s[right]);
                    windowmaxlenght = windowmaxlenght > set.Count ? windowmaxlenght : set.Count;
                    right++;
                }
            }
            return windowmaxlenght;
        }
    }
}
