using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace My_demo09_RestFul风格API
{
    public class Program
    {
        //程序入口
        //步骤：创建主机生成器-->配置主机-->创建主机-->运行主机
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {  
                    //主机配置
                    webBuilder.ConfigureKestrel((context,options)=> 
                    {
                        options.Limits.MaxRequestBodySize=1024;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
