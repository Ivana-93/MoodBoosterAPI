using FirebaseAdmin.Messaging;
using MoodAPI.Models;
using MoodAPI.Models.Auth;
using MoodAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MoodAPI.Bases
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
        private User _user;
        public User AuthorizedUser {
            get
            {
                if (_user != null)
                {
                    return _user;
                }
                try
                {
                    if (_user == null && ((ClaimsPrincipal)User).Claims.ToList()[0] != null)
                    {
                        var email = ((ClaimsPrincipal)User).Claims.ToList()[0].Value;
                        _user = FirebaseService.Instance.GetUser(GetFireBaseEmail(email));
                        return _user;
                    }
                }catch (Exception e){
                    throw new Exception($"Unable to get user. Check if you added proper attribute or if user has valid credentials.\r\nException message: {e.Message}");
                }


                return null;
            }
        }

        [NonAction]
        public string GetFireBaseEmail(string email)
        {
            return email.Replace('.', '*');
        }

        [NonAction]
        public ListResponse<T> CreateOkResponse<T>(List<T> data)
        {
            return new ListResponse<T>
            {
                Data = data,
                Message = "Success!",
                Status = HttpStatusCode.OK,
                IsSuccess = true
            };
        }

        [NonAction]
        public SingleResponse<T> CreateOkResponse<T>(T data)
        {
            return new SingleResponse<T>
            {
                Data = data,
                Message = "Success!",
                Status = HttpStatusCode.OK,
                IsSuccess = true
            };
        }

        [NonAction]
        public BaseResponse CreateOkResponse()
        {
            return new BaseResponse
            {
                Message = "Success!",
                Status = HttpStatusCode.OK,
                IsSuccess = true
            };
        }

        [NonAction]
        public ErrorResponse CreateErrorResponse(Exception e)
        {
            return CreateErrorResponse(e.Message);
        }

        [NonAction]
        public ErrorResponse CreateUnauthorizedResponse()
        {
            return new ErrorResponse
            {
                Message = "Unauthorized",
                Status = HttpStatusCode.Unauthorized,
                IsSuccess = false
            };
        }

        [NonAction]
        public ErrorResponse CreateErrorResponse(string message)
        {
            return new ErrorResponse
            {
                Message = message,
                Status = HttpStatusCode.InternalServerError,
                IsSuccess = false
            };
        }
    }
}
