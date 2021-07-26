using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_demo03_Thread线程
{
    class Program
    {
        #region Thread,ThreadPool线程池,Task ，信号量

        //博客地址：https://www.jianshu.com/p/7353a2eedc81
        //-----1-----Thread 线程
        //Thread a = new Thread(new ThreadStart(()=> { }));
        //---1.1---特性
        //Thread thread = new Thread(new ThreadStart(() => { }));
        //thread.Start();//开始
        //thread.Suspend();//挂起、暂停
        //thread.Resume(); //恢复暂停的线程 
        //thread.Abort();//停止(对外抛出ThreadAbortException异常)
        //thread.Join();//主线程等待子线程计算完成；
        //thread.Join(2000);//等待2000ms
        //thread.Priority = ThreadPriority.Normal;  //线程优先级,其实是提高优先执行的概率,有意外,优先执行并不代表优先结束(千万不要用这个来控制线程的执行顺序)
        //thread.IsBackground = true;//后台线程；进程关闭，线程也就消失了
        //thread.IsBackground = false; //前台线程：进程关闭，线程执行完计算才消失

        //-----2-----ThreadPool线程池 (ThreadPool是Thread基础上的一个线程池)
        //ThreadPool.QueueUserWorkItem( o => { });
        /*  WaitCallback waitCallback = o =>
          {
              Console.WriteLine(o.ToString());
          };*/

        //-----3-----Task任务，工厂创建，直接执行
        /*启动方式
        //第一种
        Task task = new Task(() =>  {Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00")); });
        task.Start();
        //第二种
        Task task = Task.Run(()=>{Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00")); });
        //第三种
        TaskFactory taskFactory = Task.Factory;  （ //Task.Factory.StartNew(() =>{});）
        Task task = taskFactory.StartNew(()=>{Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString("00")); });*/

        //-----4-----信号量(Semaphore) : Semaphore负责协调线程，可以限制对某一资源访问的线程数量
        /* 
         static SemaphoreSlim semLim = new SemaphoreSlim(3); //3表示最多只能有三个线程同时访问
         static void Main(string[] args)
         {
             for (int i = 0; i < 10; i++)
             {
                 new Thread(SemaphoreTest).Start();
             }
             Console.Read();
         }
         static void SemaphoreTest()
         {
             semLim.Wait();
             Console.WriteLine("线程" + Thread.CurrentThread.ManagedThreadId.ToString() + "开始执行");
             Thread.Sleep(2000);
             Console.WriteLine("线程" + Thread.CurrentThread.ManagedThreadId.ToString() + "执行完毕");
             semLim.Release();
         }
         */
        #endregion

        // async/await 异步多线程
        static async Task Main(string[] args)
        {
            Console.WriteLine("ddd:" + Thread.CurrentThread.ManagedThreadId);
            await haung();
            Console.WriteLine("aaaa:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(10000);
            Console.ReadKey();
        }
        static async Task haung()
        {
            Console.WriteLine("a:" + Thread.CurrentThread.ManagedThreadId);
            // 调用异步步方法
            await AsyncTestMethod();
            Console.WriteLine("b:" + Thread.CurrentThread.ManagedThreadId);

        }
        static async Task AsyncTestMethod()
        {
            Console.WriteLine("c:" + Thread.CurrentThread.ManagedThreadId);
            await AsyncTestMethod2();
            Console.WriteLine("d:" + Thread.CurrentThread.ManagedThreadId);
        }
        static async Task AsyncTestMethod2()
        {
            Console.WriteLine("e:" + Thread.CurrentThread.ManagedThreadId);

            await Task.Run(() => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                }
            });
            Console.WriteLine("f:" + Thread.CurrentThread.ManagedThreadId);

        }
    }
}