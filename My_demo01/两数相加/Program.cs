using System;

namespace 两数相加
{
    /*
     给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。
     请你将两个数相加，并以相同形式返回一个表示和的链表。
     你可以假设除了数字 0 之外，这两个数都不会以 0 开头。
     */
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(Int16.MaxValue);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode re = new ListNode(0);
            ListNode temp = re;   //re,temp引用相同，指向同一块区域
            int carry = 0;
            while (l1!=null || l2!=null)  //同时遍历两个链表，如果某个链表长度不够，则在后面补0
            {
                var n1 = l1 != null ? l1.Val : 0;//7  5  8
                var n2 = l2 != null ? l2.Val : 0;//8  5  1
                int sum = n1 + n2 + carry;      //15
                carry = sum / 10;  //判断是否进位 //1
                var yushu = sum % 10; //取余数   //5
                temp.Next = new ListNode(yushu);
                temp = temp.Next;
                if (l1 != null) l1 = l1.Next;
                if (l2 != null) l2 = l2.Next;
            }
            if (carry==1)
            {
                temp.Next = new ListNode(carry);
            }
            return re.Next;
        }
    }
    /// <summary>
    /// 链表类
    /// </summary>
    public class ListNode
    {
        int val;
        ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
        public int Val
        {
            get { return val; }
            set { val = value; }
        }
        public ListNode Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
