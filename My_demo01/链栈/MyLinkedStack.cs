using System;
using System.Collections.Generic;
using System.Text;
using 顺序栈;

namespace 链栈
{
    /// <summary>
    /// 链栈类
    /// </summary>
    public class MyLinkedStack<T> : StackInterface<T>
    {
        private Node<T> top; //栈顶节点
        private int count;//统计栈中元素个数
        public MyLinkedStack()
        {
            top = null;
            count = 0;
        }

        public int Count
        { 
            get  { return count; } 
        }

        public void Clear()
        {
            count = 0;
            top = null;
        }

        public int GetLength()
        {
            return Count;
        }

        public bool IsEmpty()
        {
            if (count==0)
            {
                return true;
            }
            return false;
        }

        public T Peek()
        {
            return top.Data;
        }

        public T Pop()
        {
            T  temp= top.Data;
            top = top.Next;
            count--;
            return temp;
        }

        public void Push(T Item)
        {
            //新加的元素作为头节点(栈顶)
            Node<T> newnode = new Node<T>(Item);
            newnode.Next = top;
            top = newnode;
            count++;
        }
    }
}
