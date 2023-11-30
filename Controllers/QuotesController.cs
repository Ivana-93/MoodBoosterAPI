using MoodAPI.Auth;
using MoodAPI.Bases;
using MoodAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoodAPI.Controllers
{
    [JWTAuthenticate]
    public class QuotesController : BaseController
    {
        [HttpGet]
        [Route("api/quote")]

        public BaseResponse GetQuote()
        {
            try
            {
                var quote = QuotesService.Instance.GetRandomQuote();

                AuthorizedUser.Quotes.Add(quote);
                FirebaseService.Instance.CreateAndUpdateUser(AuthorizedUser);


                return CreateOkResponse(quote);
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }
        }


        [HttpGet]
        [Route("api/quotes")]

        public BaseResponse GetUserQuotes()
        {
            try
            {
                return CreateOkResponse(AuthorizedUser.Quotes);
            }
            catch (Exception e)
            {
                return CreateErrorResponse(e);
            }
        }


    }

}

