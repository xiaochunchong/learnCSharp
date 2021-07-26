using System;

namespace 实现strStr__
{
    class Program
    {
        static void Main(string[] args)
        {
           // var str = "hello";
           // var aa = str.Substring(1,1);
            var cc= Solution.StrStr("aaaaa", "bba");
            Console.WriteLine(cc);
            Console.ReadLine();
        }
    }


    public class Solution
    {
        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(haystack) || string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack.Substring(i).Length < needle.Length)
                {
                    return -1;
                }
              if (needle ==haystack.Substring(i,needle.Length))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
