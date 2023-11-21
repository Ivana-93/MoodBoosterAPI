using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class Question
    {
        [JsonProperty("questionText")]
        public string QuestionText { get; set; }

        [JsonProperty("answers")]
        private List<Answer> answers;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonIgnore]
        public List<Answer> Answers
        {
            get
            {
                if (answers == null)
                {
                    answers = new List<Answer>();
                }
                return answers;
            }
            set
            {
                answers = value;
            }
        }
    }
}