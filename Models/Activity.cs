using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class Activity
    {
        [JsonProperty("id")]
        public string Id { get; set; }


        [JsonProperty("date")]
        public string Date { get; set; }


        [JsonProperty("content")]
        public string Content { get; set; }


        [JsonProperty("link")]
        public string Link { get; set; }
    }
}