using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_demo01
{

         /*    the test01 start thread is 1
                the Methed01 start thread is 1
                the Methed01 task start thread is 3
                the Methed01 task end thread is 3
                the Methed01 end thread is 3
                the test01 end thread is 3
                */
        class Demo01
        {
            static void Main(string[] args)
            {
                test01();
            Console.WriteLine("the Enddddddd " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
            }
            public static async void test01()
            {
                Console.WriteLine("the test01 start thread is " + Thread.CurrentThread.ManagedThreadId);
                await Methed01();
               var a = await Methed02();
                Console.WriteLine("the test01 end thread is " + Thread.CurrentThread.ManagedThreadId);
            }
            public static async Task Methed01()
            {
                Console.WriteLine("the Methed01 start thread is " + Thread.CurrentThread.ManagedThreadId);
                await Task.Run(() =>
                {
                    Console.WriteLine("the Methed01 task start thread is " + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(5 * 1000);
                    Console.WriteLine("the Methed01 task end thread is " + Thread.CurrentThread.ManagedThreadId);
                });
                Console.WriteLine("the Methed01 end thread is " + Thread.CurrentThread.ManagedThreadId);
            }
        public static async Task<int> Methed02()
        {
            Console.WriteLine("the Methed02 start thread is" + Thread.CurrentThread.ManagedThreadId);
            await Task.Run(() =>
            {
                Console.WriteLine("the Methed02 task start thread is" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10 * 1000);
                Console.WriteLine("the Methed02 task end thread is" + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("the Methed02 end thread is" + Thread.CurrentThread.ManagedThreadId);
            return 1;
        }

    }
    

}
