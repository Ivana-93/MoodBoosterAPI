using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

using MoodAPI.Models;

namespace MoodAPI.Services
{
    public class JokesService
    {

        private static JokesService instance = null;
        public static JokesService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JokesService();
                }
                return instance;
            }
        }
        private JokesService() { }

        private readonly string apiUrl = "https://v2.jokeapi.dev/joke/";

        private T Get<T>(string target, Dictionary<string, string> optionalParams)
        {
            string response = "";
            var optionalParamsString = "";
            if (optionalParams != null && optionalParams.Count > 0)
            {
                optionalParamsString += "?";
                foreach (var optionalParam in optionalParams)
                {
                    optionalParamsString += $"{optionalParam.Key}={optionalParam.Value}&";
                }
            }
            using (HttpClient http = new HttpClient())
            {
                var data = http.GetAsync($"{apiUrl}/{target}{optionalParamsString}")
                    .Result;
                response = data.Content.ReadAsStringAsync().Result;
            };
            return JsonConvert.DeserializeObject<T>(response);
            
        }

        public Joke GetRandomJoke()
        {
            var optionalParams = new Dictionary<string, string>
            {
                { "lang", "en" },
                { "type", "single" },
                { "blacklistFlags", "racist" },
            };

            var rawJoke = Get<JokeAPI.Joke>("Any", optionalParams);
         
            var joke = new Joke
            {
                Content = rawJoke.JokeText,
                Date = DateTime.Now.ToString("yyyy-MM-dd")
            };
            
            return joke;
           

        }
    }
}