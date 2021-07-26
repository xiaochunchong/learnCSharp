using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AOP_Log4Net.Filter;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AOP_Log4Net
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public static ILoggerRepository LogRepository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
       

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
          /*  services.AddMvc(options =>
            {
                options.Filters.Add<LogFilter>();
            });*/
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
