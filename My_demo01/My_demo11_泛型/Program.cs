using System;
using System.Collections.Generic;

namespace My_demo11_泛型
{
    class Program 
    {
        static void Main(string[] args)
        {
            test1<string, int>("niha", 123);
            People p = new People(); test5<People>(p); test6<People>(p); test7<People>(p);

            //---***---协变和逆变
            Human hu = new Human();
            Chinese ch = new Chinese();
            //因为Chinese是Human的子类, 子类对象赋予父类, 所以声明不会有问题
            Human hu1 = new Chinese();


            //声明list
            List<Human> hl1 = new List<Human>();
            List<Chinese> cl1 = new List<Chinese>();
            //提示无法将List<Chinese>转为List<Human>
            //这里的Human虽然是Chinese的父类，但是如果将Human，和Chinese当做List类型来用，那么这里的2个List就不再有继承关系，没有继承关系在声明的时候就会出错
            // hl1 = cl1; 

            //这时候就需要使用协变：
            List<Chinese> human1 = new List<Chinese>();
            IEnumerable<Human> human = human1;


            Ixieibian<Human> xie = new xiebian<Chinese>();

            //逆变
            Inibian<Chinese> ni = new nibian<Human>();

        }
        /* 注意：
         --不可能同时添加struct和class约束
         --不可能添加多个基类约束
         --约束之间是 and 关系，不能添加or关系的约束
         --构造器约束必须最后
         --构造器约束只能指明无参构造器
         --约束不会继承
        */

        //泛型的默认值
        //使用default关键字来获取泛型类型参数的默认值
        static void zap<T>(T[] array) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                //如果T是引用类型，默认值是null；值类型T默认值是0
                array[i] = default(T);
            }
        }

        //泛型方法
        public static void test1<T1, T2>(T1 t1, T2 t2)
        {
            Console.WriteLine($"{t1.ToString()},{t2}");
        }

        //构造函数约束
        //表示T类型必须要有一个无参的构造函数new T()，可以实例化的T类型
        public static void test2<T,T2>(T t,T2 t2) 
            where T  : new()
            where T2 : new()
        {
            Console.WriteLine($"{t.ToString()}");
        }

        //值类型约束 
        //表示T类型必须是值类型(int,bool,double,struct......)，但并不包括可空的值类型
        public static void test3<T>(T t) where T : struct
        {
            Console.WriteLine($"{t.ToString()}");
        }

        //引用类型约束 
        //表示T类型必须是引用类型(类,接口,委托,string,数组......)
        public static void test4<T>(T t) where T : class
        {
            Console.WriteLine($"{t.ToString()}");
        }

        //where T:基类名 ，基类约束 
        //表示类型参数必须是继承自指定的基类，或是基类本身
        public static void test5<T>(T t) where T : People
        {
            Console.WriteLine($"{t.ToString()}");
        }

        //where T:接口名， 接口约束 
        //表示类型参数必须是实现指定接口，或是指定接口
        public static void test6<T>(T t) where T : animal
        {
            Console.WriteLine($"{t.ToString()}");
        }

        //where T : U， 裸类型约束
        //表示为 T 提供的类型参数必须是为 U 提供的参数或派生自为 U 提供的参数
        public static void test7<T>(T t) where T : animal
        {
            Console.WriteLine($"{t.ToString()}");
        }

    }
    class People :animal
    {
        string name;
    }
    class People2 : People
    {
        string name1;
    }
    interface animal
    {
    }
}
  