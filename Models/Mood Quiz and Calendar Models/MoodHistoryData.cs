using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace MoodAPI.Models
{
    public class MoodHistoryData
    {
        [JsonProperty("moodCreated")]
        public DateTime MoodCreated { get; set; }


        [JsonProperty("moodTypeResult")]
        public string MoodTypeResult { get; set; }
    }
}