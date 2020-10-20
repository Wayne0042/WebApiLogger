using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiLogger.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestLogController : ApiController
    {
        [HttpGet]
        public object TestGet()
        {
            return new { status = "200", msg = "test ok" };
        }
    }
}
