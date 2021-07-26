using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOP_Log4Net.Filter
{
    //ActionFilterAttribute类是个特性类，而且实现IActionFilter过滤器接口
    //当我们使用一个特性类时，相当于调用了这个特性类的构造方法
    public class LogFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("action");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("end");
        }
    }
}
