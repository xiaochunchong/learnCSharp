using System;
using System.Collections.Generic;
using System.Text;

namespace My_demo11_泛型
{
    /// <summary>
    /// 协变和逆变
    /// </summary>
    class InAndOut{}

    public class Human 
    {
        public string name { get; set; }
    }

    public class Chinese : Human
    {
        public string age { get; set; }
    }

    //协变
    //协变的类型参数T只能作为返回结果，不能作为参数
    interface Ixieibian<out T> 
    {
        T Create();
    }
    class xiebian<T> : Ixieibian<T>
    {
        public T Create()
        {
            return default(T);
        }
    }

    //逆变
    //T只能做为参数，不能做返回值
    interface Inibian<in T> 
    {
        void Create(T t);
    }
    class nibian<T> : Inibian<T>
    {
        public void Create(T t)
        {
        }
    }

}
