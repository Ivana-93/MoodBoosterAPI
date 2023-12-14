using MoodAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;


namespace MoodAPI.Services
{
    public class TriviaService
    { 
        private static TriviaService instance;

        public static TriviaService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TriviaService();
                }
                return instance;
            }
        }

        public TriviaService() {}

        private readonly string apiUrl = "https://opentdb.com/api.php?amount=10";

        private T Get<T>(){

            var response = "";
            using (HttpClient http = new HttpClient())
            {
                var data = http.GetAsync($"{apiUrl}").Result;
                response = data.Content.ReadAsStringAsync().Result;
            }

            return JsonConvert.DeserializeObject<T>(response);
        }

        public List<TriviaQuestion> GetTriviaQuestions()
        {

            var triviaAPI = Get<TriviaAPIResponse>();

            if (triviaAPI != null)
            {
                return triviaAPI.Results;
            }

            return null;
        }

    }
  
}