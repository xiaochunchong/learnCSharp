using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.StackExchangeRedis;  //Redis相关
using Microsoft.Extensions.Caching.Distributed;  //分布式相关的命名空间
using System.IO;
using Redis实现分布式缓存.Models;
using System.Diagnostics;
using System.Threading;
using Infrastructure.Redis;
using Microsoft.AspNetCore.Http;

namespace Redis实现分布式缓存.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase    
    {
        private RedisCache rc;
        public IRedisCacheManager _redisCacheManager;
        public IHttpContextAccessor _httpContextAccessor;
        #region 弃用
        /* 
         //初始化Redis对象,实例化时构造方法需要传入redis配置对象信息
         private RedisCache rc;
         public StudentController()
         {
             RedisCacheOptions rco = new RedisCacheOptions()  //redis配置对象
             {
                 //配置连接地址 
                 Configuration = "127.0.0.1:6379,password=123456",
                 //配置redis对象别称
                 InstanceName = "MyRedis"
             };

             rc = new RedisCache(rco);
         }
         */
        #endregion

        public StudentController(IRedisCacheManager redisCacheManager, IHttpContextAccessor httpContextAccessor)
        {
            _redisCacheManager = redisCacheManager;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("write")]
        public ActionResult<string> write(string id) 
        {
            /* 计算时间间隔
               Stopwatch tt = new Stopwatch();
               tt.Start();
               Thread.Sleep(2000);
               tt.Stop();
               Console.WriteLine(tt.ElapsedMilliseconds);
               */
            
            #region  弃用
            /*  Person stu = new Person()
              {
                  Name = "Tom",
                  Age = 20,
                  Number = "10086"
              };
              var stujson = JsonConvert.SerializeObject(stu);
              //设置数据缓存过期时间为60s，到期自动删除
              //Distributed  翻译 ：分布式
              var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));  
              //1.打开redis服务，cmd进入窗口使用 redis-service 启动
              //2.使用redis的set方法保存数据    
              rc.SetString("tomkey" , stujson);
              rc.SetString("livetime", DateTime.Now.ToString(),option);
              return "sussess";*/
            #endregion
            var key = id;
            object a = new object();
            if (_redisCacheManager.Get<object>(key) != null)
            {
                a = _redisCacheManager.Get<object>(key);
            }
            else
            {
                _redisCacheManager.Set(key, $"{new Random().Next(0,100)}", TimeSpan.FromHours(2));//缓存2小时
            }

            return a.ToString();

        }

        /// <summary>
        /// 读
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("read")]
        public string read()
        {
            var aa = rc.GetString("livetime");
            var stu = JsonConvert.DeserializeObject<Person>(rc.GetString("tomkey"));
            return stu.Name+stu.Number+stu.Age + ":" + aa;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("removedata")]
        public string removedata()
        {
            rc.Remove("tomkey");
            return "删除成功";
        }
    }

}
