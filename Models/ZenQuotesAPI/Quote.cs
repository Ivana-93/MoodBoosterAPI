using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace MoodAPI.ZenQuotesAPI
{
    public class QuoteAPI
    { 
        
        [JsonProperty ("q")]
        public string QuoteText { get; set; }

        [JsonProperty("a")]
        public string AuthorName { get; set; }

        [JsonProperty("i")]
        public string AuthorImage { get; set; }

        [JsonProperty("c")]
        public string CharacterCount { get; set; }

        [JsonProperty("h")]
        public string PreformatedQuote { get; set; }

    }
}