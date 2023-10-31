using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models.Auth
{
    [Serializable]
    public class Users
    {
        [JsonProperty("userData")]
        public Dictionary<string, string> UserData { get; set; }

    }
}