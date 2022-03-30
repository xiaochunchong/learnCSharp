using System;
using System.Collections.Generic;
using System.Text;

namespace 顺序栈
{
    /// <summary>
    /// 实现接口方法（用数组实现顺序栈）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T> : StackInterface<T>
    {
        private T[] data;
        private int top;

        public MyStack(int size)
        {
            data = new T[size];
            top = -1;
        }
        public MyStack() :this(10) //默认10个
        {
        }
        public int Count { 
            get 
            {
                return top + 1;
            }
        }
        public void Clear()
        {
            top = -1;
        }
        public int GetLength()
        {
            return Count;
        }
        public bool IsEmpty()
        {
            if (Count==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public T Peek()
        {
            return data[top];
        }
        public T Pop()
        {
            T temp = data[top];
            top--;
            return temp;
        }
        public void Push(T Item)
        {
            data[top + 1] = Item;
            top++;
        }
    }
}
