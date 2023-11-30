using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models.Auth
{
    public class RefreshTokenRequest
    {
        [JsonProperty("userId")]
        public string UserID { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}