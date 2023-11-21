using MoodAPI.Models;
using MoodAPI.Models.Auth;
using MoodAPI.Models.Diary_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web.Helpers;

namespace MoodAPI.Services
{
    public class FirebaseService
    {
        private static FirebaseService firebaseService = null;
        public static FirebaseService Instance
        {
            get
            {
                if (firebaseService == null)
                {
                    firebaseService = new FirebaseService();
                }
                return firebaseService;
            }
        }
        private FirebaseService() { }


        //GET method for connection to firebase to retrive data
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        private T Get<T>(string filename)
        {
            string response = "";
            using (HttpClient http = new HttpClient())
            {
                var data = http.GetAsync($"https://ng-mood-booster-default-rtdb.europe-west1.firebasedatabase.app/{filename}.json")
                    .Result;
                response = data.Content.ReadAsStringAsync().Result;
            };

            return JsonConvert.DeserializeObject<T>(response);
        }

        //DELETE method 
        private void Delete(string filename)
        {
            using (HttpClient http = new HttpClient())
            {
                var data = http.DeleteAsync($"https://ng-mood-booster-default-rtdb.europe-west1.firebasedatabase.app/{filename}.json")
                    .Result;
            };
        }

        /// <summary>
        /// PATCH method for connection to firebase to update data - PATCH works better for Firebase then POST
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="filename"></param>
        private void Patch<T>(T value, string filename)
        {
            string response = "";

            using (HttpClient http = new HttpClient())
            {
                var data = http.PatchAsJsonAsync(
                    $"https://ng-mood-booster-default-rtdb.europe-west1.firebasedatabase.app/{filename}.json",
                    value
                    ).Result;
                response = data.Content.ReadAsStringAsync().Result;
            };

            Console.WriteLine(response);
        }


        //Method for geting users
        public Users GetUsers()
        {
            return Get<Users>("users");
        }


        //Method for catching user from users
        public User GetUser(string email)
        {
            var users = GetUsers();

            if (!users.UserData.TryGetValue(email, out string id))
            {
                return null;
            }

            var user = Get<User>(id);
            if (user == null)
            {
                return null;
            }
            user.Id = id;

            return user;

        }

        //Method for the case when we don't have any userdata in users
        public void CreateUsers()
        {
            var dict = new Dictionary<string, string>
            {
                ["dummy"] = "dummy1"
            };
            Patch(dict, "users/userData");
        }


        // Patch - create and update user;
        public void CreateAndUpdateUser(User user)
        {
            Patch(user, user.Id);
        }


        //Update users in userdata file
        public void UpdateUsers(string id, string email)
        {
            var dict = new Dictionary<string, string>
            {
                [email] = id
            };
            Patch(dict, "users/userData");
        }

        //Delete user form userdata
        public void DeleteFromUsers(string email)
        {
            Delete($"users/userData/{email}");
        }

        //Method for retriving quotes 
        public string GetQuote(string id)
        {
            return Get<string>(id);
        }

        //Method for adding questions in Firebase database
        public void AddQuestions(Questions questions)
        {
            Patch(questions, "/questions");
        }

        //Method for retriving questions from Firebase database
        public Questions GetQuestions()
        {
            return Get<Questions>("questions");
        }


        //Method for adding mood results in Firebase database (so you don't need to write it in Firebase because this is easier)
        public void AddMoodResult (MoodQuizResult moodResult)
        {
            Patch(moodResult, "/mood_result");
        }

        //Method for geting mood quiz result from FirebaseDatabase
        public MoodQuizResult GetMoodResult()
        {
            return Get<MoodQuizResult>("mood_result");
        }


    }
    
}

