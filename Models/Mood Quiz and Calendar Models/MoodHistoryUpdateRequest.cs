using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class MoodHistoryUpdateRequest
    {
        [JsonProperty("moodType")]
        public string MoodType { get; set; }
    }
}