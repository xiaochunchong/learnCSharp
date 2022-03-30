using System;
using System.Collections.Generic;
using System.Text;

namespace 链栈
{
    /// <summary>
    /// 链栈节点类
    /// </summary>
    class Node<T>
    {
        private T data; //本节点数据
        private Node<T> next; //next存放的是下一节点地址，会访问到下一节点信息
        public T Data 
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public Node()
        {
            data = default(T);
            next = null;
        }
        public Node(T Item)
        {
            data = Item;
            next = null;
        }
        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
        public Node(Node<T> next)
        {
            this.next = next;
            data = default(T);
        }
    }
}
