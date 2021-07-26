using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_demo09_RestFul风格API.Controllers { 
    [ApiController]
    [Route("api/[controller]")]
    public class MydemoControllers : ControllerBase
    {
    [HttpGet]
    [Route("FirstApi/{a}")]
    public ActionResult<string> FirstApi(int a) 
    {
        return "a";
    }

    }
}
