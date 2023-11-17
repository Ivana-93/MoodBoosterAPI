using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MoodAPI.Models.Auth
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("quotes")]
        private List<Quote> quotes;

        [JsonProperty("joke")]
        public Joke Joke;

        [JsonProperty("activity")]
        public Activity Activity;
            

        public List<Quote> Quotes
        {
            get
            {
                if (quotes == null)
                {
                    quotes = new List<Quote>();
                }
                return quotes;
            }
            set
            {
                quotes = value;
            }
        }
    }
}