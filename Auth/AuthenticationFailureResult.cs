using MoodAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Text.Json;
using System.Net.Http.Json;

namespace MoodAPI.Auth
{
    public class AuthenticationFailureResult : IHttpActionResult
    {

        public HttpRequestMessage Request { get; private set; }

        public string Message { get; set; }

        public AuthenticationFailureResult(Exception exception, HttpRequestMessage request)
        {
            Request = request;
            Message = exception.Message;
        }

        public AuthenticationFailureResult(string message, HttpRequestMessage request)
        {
            Request = request;
            Message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                RequestMessage = Request,
                Content = JsonContent.Create(
                    new ErrorResponse
                    {
                        Message = Message,
                        Status = HttpStatusCode.Unauthorized,
                        IsSuccess = false
                    },
                    null,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        IncludeFields = true
                    })
            };
            return response;
        }
    }
}