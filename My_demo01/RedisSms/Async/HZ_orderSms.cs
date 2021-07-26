using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RedisSms.Async
{
    /// <summary>
    /// 订单短信服务
    /// </summary>
    public class HZ_orderSms
    {
        public void SendSms(string order_sn) 
        {

            //--1--假设调用第三方短信接口服务
            Thread.Sleep(1000);
            //--2--短信发送成功
            Console.WriteLine($"发送短信：{order_sn} 成功");

        }
    }
}
