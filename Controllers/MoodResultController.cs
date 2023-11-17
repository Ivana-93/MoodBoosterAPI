using Microsoft.Ajax.Utilities;
using MoodAPI.Bases;
using MoodAPI.Models;
using MoodAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MoodAPI.Controllers
{
    public class MoodResultController : BaseController
    {
        [HttpPost]
        [Route("api/addmoodresult")]
        public BaseResponse AddMoodResult()
        {

            var moodResult = new MoodQuizResult
            {
                Moods = new Dictionary<string, string>
                {
                    { "Apathetic" ,"Today, you just don't care. Nothing motivates you and you are lacking od enthusiasm. Maybe you feel apathetic because nothing around you stirs your interest, or maybe it’s because you need some coffee. Try to make it through the day one thing at the time. And don’t forget to eat well and drink enough water! "},
                    { "Cheerful" , "Today is good day, and you are in the good mood! You either sleep well, got good news, or you're just a generally positive person. Good for you! Stay that way and have a great day! Maybe even try to share your energy with people around you!" },
                    { "Depressed" , "Today, you have the blues. Your spirits are low because of something that happened in your life or the cause could be chemical or biological. Have you considered talking to someone about how you feel? We all have those moments where we feel like a lone vessel out at sea. The only cure for loneliness is to try and reach out to a friend or loved one. Take care of yourself and don’t forget – tomorrow is a new day!" },
                }
            };

            try
            {
                FirebaseService.Instance.AddMoodResult(moodResult);
                return CreateOkResponse();
            }

            catch (Exception e)
            {
                return CreateErrorResponse(e.Message);
            };
        }



        [HttpPost]
        [Route("api/moodresult")]


        public BaseResponse SendMoodResult([FromBody] PointsCount reqBody)
        {


            try
            {

                var moodResult = FirebaseService.Instance.GetMoodResult();

                if (reqBody.PointCount < 15)
                {
                    if (!moodResult.Moods.ContainsKey("Depressed"))
                    {

                        throw new ArgumentNullException(nameof(moodResult.Moods));
                    }

                    var responseData = new MoodQuizResultResponse
                    {
                        MoodType = "Depressed",
                        MoodText = moodResult.Moods["Depressed"]
                    };

                    return CreateOkResponse(responseData);
                }
                else if (reqBody.PointCount > 15 && reqBody.PointCount < 23)
                {

                    if (!moodResult.Moods.ContainsKey("Apathetic"))
                    {

                        throw new ArgumentNullException(nameof(moodResult.Moods));
                    }

                    var responseData = new MoodQuizResultResponse
                    {
                        MoodType = "Apathetic",
                        MoodText = moodResult.Moods["Apathetic"]
                    };

                    return CreateOkResponse(responseData);
                }

                else
                {

                    if (!moodResult.Moods.ContainsKey("Cheerful"))
                    {

                        throw new ArgumentNullException(nameof(moodResult.Moods));
                    }

                    var responseData = new MoodQuizResultResponse
                    {
                        MoodType = "Cheerful",
                        MoodText = moodResult.Moods["Cheerful"]
                    };

                    return CreateOkResponse(responseData);
                }
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e.Message);
            }

        }
    }
}
