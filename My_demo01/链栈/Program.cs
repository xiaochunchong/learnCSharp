using System;

namespace 链栈
{
    class Program
    {
        /// <summary>
        /// 用链表实现链栈
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MyLinkedStack<char> mt = new MyLinkedStack<char>();
            mt.Push('1');
            mt.Push('2');
            mt.Push('3');
            mt.Push('4');
            mt.Push('5');
            Console.WriteLine("是否为空:" + mt.IsEmpty());
            Console.WriteLine("总数：" + mt.Count);
            Console.WriteLine("栈顶：" + mt.Peek());
            Console.WriteLine("移除" + mt.Pop());
            Console.WriteLine("总数：" + mt.GetLength());
            Console.WriteLine("栈顶：" + mt.Peek());
            Console.WriteLine("是否为空:" + mt.IsEmpty());
            mt.Clear();
            Console.WriteLine("是否为空:" + mt.IsEmpty());
            Console.ReadLine();
        }
    }
}
