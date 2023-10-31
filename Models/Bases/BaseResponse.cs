using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MoodAPI.Bases
{
    public class BaseResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [NonSerialized]
        internal readonly DateTime _timestamp;

        [JsonProperty("timestamp")]
        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }
        }

        public BaseResponse()
        {
            _timestamp = DateTime.Now;
        }
    }
}