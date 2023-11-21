using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models.Diary_Models
{
    public class DiaryData
    {
     
            [JsonProperty("created")]
            public DateTime Created { get; set; }


            [JsonProperty("text")]
            public string Text { get; set; }
    }

}