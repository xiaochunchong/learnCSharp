using System;
using System.Collections.Generic;
using System.Text;

namespace 顺序栈
{
   public  interface StackInterface<T>
    {
        public int Count { get;  }
        /// <summary>
        /// 获取长度
        /// </summary>
        /// <returns></returns>
        public int GetLength();
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty();
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="Item"></param>
        public void Push(T Item);
        /// <summary>
        /// 出栈，并返回出栈数据
        /// </summary>
        /// <returns></returns>
        public T Pop();
        /// <summary>
        /// 取得栈顶数据
        /// </summary>
        /// <returns></returns>
        public T Peek();
        /// <summary>
        /// 清空所有数据
        /// </summary>
        public void Clear();
    }
}
