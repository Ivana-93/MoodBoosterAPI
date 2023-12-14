using MoodAPI.Bases;
using Newtonsoft.Json;
using System.Collections.Generic;

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