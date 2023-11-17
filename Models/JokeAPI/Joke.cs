using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodAPI.JokeAPI
{
    public class Joke
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("joke")]
        public string JokeText { get; set; }

        [JsonProperty("flags")]
        public JokeFlags Flags { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("safe")]
        public bool Safe { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }
    }

    [Serializable]
    public class JokeFlags
    {
        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }       
        
        [JsonProperty("religious")]
        public bool Religious { get; set; }

        [JsonProperty("political")]
        public bool Political { get; set; }

        [JsonProperty("racist")]
        public bool Racist { get; set; }

        [JsonProperty("sexist")]
        public bool Sexist { get; set; }

        [JsonProperty("explicit")]
        public bool Explicit { get; set; }
    }
}