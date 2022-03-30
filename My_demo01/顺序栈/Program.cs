using System;

namespace 顺序栈
{
    class Program
    {
        /// <summary>
        /// 用数组实现顺序栈
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MyStack<char> mt = new MyStack<char>();
            mt.Push('1');
            mt.Push('2');
            mt.Push('3');
            mt.Push('4');
            mt.Push('5');
            Console.WriteLine("总数："+mt.Count);
            Console.WriteLine("移除" + mt.Pop());
            Console.WriteLine("总数：" + mt.GetLength());
            Console.WriteLine("栈顶：" + mt.Peek());
            Console.ReadLine();
        }
    }
}
