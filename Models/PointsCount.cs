using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class PointsCount
    {
        [JsonProperty("pointCount")]
        public int PointCount {  get; set; }
    }
}