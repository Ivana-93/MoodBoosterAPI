using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models.DiaryModels
{
    public class DiaryDataRequest
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}