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
    [JWTAuthenticate]
    public class MoodHistoryDataController : BaseController
    {
        
        [HttpPost]
        [Route("api/moodhistory")]
        public BaseResponse UpdateMoodHistory([FromBody] MoodHistoryUpdateRequest historyData)
        {
            try
            {
                var moodHistoryData = new MoodHistoryData
                {
                    MoodTypeResult = historyData.MoodType,
                    MoodCreated = DateTime.Now,
                };

                AuthorizedUser.MoodData.Add(moodHistoryData);
                FirebaseService.Instance.CreateAndUpdateUser(AuthorizedUser);
                return CreateOkResponse();
            }
            catch (Exception e) 
            {
                return CreateErrorResponse(e);
            }
          
        }


        [HttpGet]
        [Route("api/moodcalendar")]

        public BaseResponse UpdateMoodCalendar()
        {
            try 
            {
                return CreateOkResponse(AuthorizedUser.MoodData);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e);
            }
        }

    }

}


