using Microsoft.Ajax.Utilities;
using MoodAPI.Models;
using MoodAPI.ZenQuotesAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Web;

namespace MoodAPI.Services
{
    public class QuotesService

    {
        private static QuotesService instance = null;
        public static QuotesService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuotesService();
                }
                return instance;
            }
        }


        private readonly string apiUrl = "https://zenquotes.io/api/";

        private T Get<T>(string target)
        {
            var response = "";

            using (HttpClient http = new HttpClient())
            {
                var data = http.GetAsync($"{apiUrl}/{target}")
                    .Result;
              
                response = data.Content.ReadAsStringAsync().Result;
             
            };

            return JsonConvert.DeserializeObject<T>(response);
        }

        public Quote GetRandomQuote()
        {

            var rawQuote = Get<List<QuoteAPI>>("random");

            if (rawQuote?.Count == 0)
            {
                return null;
            }

            var quote = new Quote
            {
                Id = Guid.NewGuid().ToString(),
                Content = $"\"{rawQuote[0].QuoteText}\"\n{rawQuote[0].AuthorName}",
                DateCreated = DateTime.Now
            };

            return quote;


        }
    }
}