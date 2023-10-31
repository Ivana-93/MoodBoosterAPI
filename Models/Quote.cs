using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.Models
{
    public class Quote
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}