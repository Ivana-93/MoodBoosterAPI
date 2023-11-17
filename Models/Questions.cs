using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class Questions
    {
        [JsonProperty("questionList")]
        private List<Question> questionList;

        [JsonIgnore]
        public List<Question> QuestionList
        {
            get
            {
                if (questionList == null)
                {
                    questionList = new List<Question>();
                }
                return questionList;
            }
            set
            {
                questionList = value;
            }
        }
    }
}
