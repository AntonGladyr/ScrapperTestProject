using System;
using Newtonsoft.Json;

namespace TestProject.Models
{
    public class RedditNews
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("num_comments")]
        public int CommentsNumber { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("url")]
        public string ImageURL { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("created_utc")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("subreddit_name_prefixed")]
        public string SubredditName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        //[JsonProperty("after")]
        //public string AfterID { get; set; }
    }
}
