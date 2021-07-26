using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RedisPoints.Async
{
    /// <summary>
    /// 订单积分服务
    /// </summary>
    public class HZ_orderPoints
    {
        public void addpoint(string order_sn) 
        {
            //1--假装调用积分服务
            Thread.Sleep(1000);
            //--2--发送积分成功
            Console.WriteLine($"发送积分：{order_sn}成功");
        }


    }
}
