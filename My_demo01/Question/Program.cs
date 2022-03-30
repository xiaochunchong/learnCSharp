using System;
using System.Collections.Generic;

namespace Question
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution.IsValid("()");
        }

    }

    public class Solution
    {
        public static  bool IsValid(string s)
        {
            if (s.Length%2!=0)
            {
                return false;
            }
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]=='(')
                {
                    st.Push(')');
                }
                else if (s[i] == '[')
                {
                    st.Push(']');
                }
                else if (s[i] == '{')
                {
                    st.Push('}');
                }
                else if(st.Count==0 || s[i]!=st.Pop())
                {
                    return false;
                }
            }
            return st.Count==0?false:true;
        }
    }

}
