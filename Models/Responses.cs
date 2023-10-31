using MoodAPI.Bases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class ErrorResponse : BaseResponse
    {
    }

    public class ListResponse<T> : BaseResponse
    {
        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }

    public class SingleResponse<T> : BaseResponse
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}