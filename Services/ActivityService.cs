using MoodAPI.Models;
using MoodAPI.Models.HumorAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MoodAPI.Services
{
    public class ActivityService
    {
        private static ActivityService instance = null;

        public static ActivityService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActivityService();
                }
                return instance;
            }
        }

        private ActivityService() { }

        private readonly string apiUrl = "http://www.boredapi.com/api/activity/";

        private T Get<T>()
        {
            string response = "";
            using (HttpClient http = new HttpClient())
            {
                var data = http.GetAsync($"{apiUrl}")
                    .Result;
                response = data.Content.ReadAsStringAsync().Result;
            };
            return JsonConvert.DeserializeObject<T>(response);
            

        }

        public Activity GetRandomActivity()
        {
            var rawActivity = Get<ActivityAPI>();

            var activity = new Activity
            {
                Id = Guid.NewGuid().ToString(),
                Content = rawActivity.Activity,
                Link = rawActivity.Url,
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
            };

            return activity;


        }
    }
}

