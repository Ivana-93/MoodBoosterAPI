using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models.HumorAPI
{
    public class ActivityAPI
    {
        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("accessibility")]
        public float Accessibility { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("participant")]
        public int Participant { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("link")]
        public string Url { get; set; }

        [JsonProperty("key")]
        public int Id { get; set; }

    }
}