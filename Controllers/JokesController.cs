using MoodAPI.Auth;
using MoodAPI.Bases;
using MoodAPI.Models;
using MoodAPI.Models.Auth;
using MoodAPI.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MoodAPI.Controllers
{
    [JWTAuthenticate]
    public class JokesController : BaseController
    {

        [HttpGet]
        [Route("api/joke")]
        public BaseResponse GetJoke()
        {
            try
            {
                if (AuthorizedUser.Joke == null || !AuthorizedUser.Joke.Date.Equals(Helper.GetTodayDate()))
                {
                    AuthorizedUser.Joke = JokesService.Instance.GetRandomJoke();

                    FirebaseService.Instance.CreateAndUpdateUser(AuthorizedUser); //kreso fix to save it to firebase
                }

                return CreateOkResponse(AuthorizedUser.Joke);
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }
        }
    }
}
