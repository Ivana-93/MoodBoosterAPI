using MoodAPI.Bases;
using MoodAPI.Services;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace MoodAPI.Controllers
{
    public class TriviaController : BaseController
    {
        [HttpGet]
        [Route("api/trivia")]

        public BaseResponse GetTriviaQuestions()
        {
            try
            {
                var trivia = TriviaService.Instance.GetTriviaQuestions() ?? throw new HttpException("Error happened during trivia fetch");
                foreach ( var item in trivia )
                {
                    item.Question = WebUtility.HtmlDecode(item.Question);
                    for (int i = 0; i < item.IncorrectAnswers.Count; i++)
                    {
                        item.IncorrectAnswers[i] = WebUtility.HtmlDecode(item.IncorrectAnswers[i]);
                    }
                    item.CorrectAnswer = WebUtility.HtmlDecode(item.CorrectAnswer);
                }
                
                return CreateOkResponse(trivia);
            }
            catch (HttpException ex) 
            {
                return CreateErrorResponse(ex, HttpStatusCode.BadGateway);
            }            
            catch (Exception ex) 
            {
                return CreateErrorResponse(ex);
            }
        }
    }
}
