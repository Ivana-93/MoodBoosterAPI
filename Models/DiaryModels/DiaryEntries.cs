using MoodAPI.Models.Diary_Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoodAPI.Models.DiaryModels
{
    public class DiaryEntries
    {
        [JsonProperty("entries")]
        private List<DiaryData> entries;

        [JsonIgnore]
        public List<DiaryData> Entries
        {
            get
            {
                if (entries == null)
                {
                    entries = new List<DiaryData>();
                }
                return entries;
            }
            set
            {
                entries = value;
            }
        }

    }
}