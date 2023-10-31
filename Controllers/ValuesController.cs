using MoodAPI.Auth;
using MoodAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoodAPI.Controllers
{
    [JWTAuthenticate]
    public class ValuesController : BaseController
    {
        [HttpGet]
        [Route("api/values")]
        public string GetOneString()
        {
            return "one string";
        }
    }
}
