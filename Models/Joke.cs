using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class Joke
    {
        [JsonProperty("content")]
        public string Content {  get; set; }
        [JsonProperty("date")]
        public string Date {  get; set; }
        //....
    }
}