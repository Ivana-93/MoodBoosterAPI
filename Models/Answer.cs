using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class Answer
    {
        [JsonProperty("point")]
        public int Point { get; set; }

        [JsonProperty("answerText")]
        public string AnswerText { get; set; }
    }
}