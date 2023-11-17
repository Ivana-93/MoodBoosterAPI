using MoodAPI.Auth;
using MoodAPI.Bases;
using MoodAPI.Models;
using MoodAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MoodAPI.Controllers
{
    public class ActivityController : BaseController
    {
        [HttpGet]
        [Route("api/activity")]

        public BaseResponse GetActivity()
        {
            try
            {
                var activity = ActivityService.Instance.GetRandomActivity();
                return CreateOkResponse(activity);
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }
        }
    }

}
