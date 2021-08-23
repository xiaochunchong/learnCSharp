using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_demo13_整合Dapper.DapperHelper
{
    public class DataBaseConfig
    {
        private string mysqlconnectionstring;
        public string Mysqlconnectionstring { 
            get
            { 
                return mysqlconnectionstring; 
            }
        }
        public DataBaseConfig(IConfiguration Configuration)
        {
            mysqlconnectionstring = Configuration.GetConnectionString("DefaultConnection");
        }
    }
}
