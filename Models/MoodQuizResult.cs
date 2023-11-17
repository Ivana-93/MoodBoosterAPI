using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class MoodQuizResult
    {
        [JsonProperty("moods")]
        public Dictionary<string, string> Moods {  get; set; }

    }
}