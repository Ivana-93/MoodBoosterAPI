using Newtonsoft.Json;
using System.Collections.Generic;


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
