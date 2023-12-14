using Newtonsoft.Json;
using System.Collections.Generic;


namespace MoodAPI.Models
{
    public class TriviaAPIResponse
    {
        public int ResponseCode { get; set; }

        [JsonProperty("results")]
        public List<TriviaQuestion> Results { get; set; }
    }
}