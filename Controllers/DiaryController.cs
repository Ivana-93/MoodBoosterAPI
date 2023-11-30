using Microsoft.Ajax.Utilities;
using MoodAPI.Auth;
using MoodAPI.Bases;
using MoodAPI.Models;
using MoodAPI.Models.Diary_Models;
using MoodAPI.Models.DiaryModels;
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
    public class DiaryController : BaseController
    {
        [HttpPost]
        [Route("api/newdiaryentry")]
        public BaseResponse UpdateDiaryEntry([FromBody] DiaryDataRequest diaryRequest)
        {
            try
            {
                var diaryEntry = new DiaryData
                {
                    Text = diaryRequest.Text,
                    Created = DateTime.Now,
                };

                AuthorizedUser.DiaryData.Add(diaryEntry);
                FirebaseService.Instance.CreateAndUpdateUser(AuthorizedUser);
                return CreateOkResponse();
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e);
            }

        }

        [HttpGet]
        [Route("api/diaryentry")]

        public BaseResponse GetDiaryEntries()
        {
            try
            {
                return CreateOkResponse(AuthorizedUser.DiaryData);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e);
            }
        }

    }
}
