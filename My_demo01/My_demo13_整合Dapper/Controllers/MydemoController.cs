using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using My_demo13_整合Dapper.DapperHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_demo13_整合Dapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MydemoController : ControllerBase
    {
        public IDapper _IDapper;
        public IConfiguration _Configuration;
        public MydemoController(IDapper Idapper)
        {
            _IDapper = Idapper;
        }

        [HttpGet]
        [Route("FirstApi")]
        public  async Task<ActionResult<string>> FirstApi(int a)
        {
            var age =18;
            #region 
            /* var lian = new DataBaseConfig(_Configuration);
             using (MySqlConnection conn = new MySqlConnection(lian.Mysqlconnectionstring))
             {
                 agee= conn.Query<string>("select name from stu where age =@age;" , new { age = 18 }).FirstOrDefault();
             }*/
            #endregion
            var aaa =  _IDapper.QueryList<object>( "select * from stu where age =@age;",new { age=age}).FirstOrDefault();
            return "a";
        }

    }
}
