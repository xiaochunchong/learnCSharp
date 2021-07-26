using IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Redis消息队列.Async
{
    /// <summary>
    /// 生成订单
    /// </summary>
    public class HZ_order
    {
        public string creatorder()
        {
            //统计时间
            Stopwatch ttime = new Stopwatch();
            ttime.Start();

            //1--创建订单
            var orderid = this.orderGenrator();
            //1.1--模拟订单存储到数据库
            Thread.Sleep(1000);
            Console.WriteLine($"订单：{orderid},存储成功");
            Console.WriteLine("当前线程a_id: "+Thread.CurrentThread.ManagedThreadId);

            var t1 = new Task(() =>
            {   //2--添加积分
                Console.WriteLine("当前线程b_id: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("******************开始调用积分服务*************************");
                HZ_orderPoints hp = new HZ_orderPoints();
                hp.addpoint(orderid);
                Console.WriteLine("******************积分服务调用完成*************************");
            });
            Console.WriteLine("当前线程c_id: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(t1.Status);
            t1.Start();

            var t2 = new Task(() =>
            {  //3--发送短信
                Console.WriteLine("当前线程d_id: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("******************开始调用短信服务*************************");
                HZ_orderSms hs = new HZ_orderSms();
                hs.SendSms(orderid);
                Console.WriteLine("******************短信服务调用完成*************************");
            });
            Console.WriteLine(t2.Status);
            t2.Start();
            Console.WriteLine("当前线程e_id: " + Thread.CurrentThread.ManagedThreadId);
            ttime.Stop();
            Console.WriteLine($"订单完成耗时:{ttime.ElapsedMilliseconds}ms");
            return orderid;
        }
        /// <summary>
        /// 订单生成器
        /// </summary>
        /// <returns></returns>
        private string orderGenrator() 
        { 
            Random aaa = new Random();
            string orderid = "R" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + aaa.Next(1000, 9999).ToString();
            return orderid;
        }

    }
}
