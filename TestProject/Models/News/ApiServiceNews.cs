using System;
using Newtonsoft.Json;

namespace TestProject.Models
{
    public class ApiServiceNews
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Permalink { get; set; }

        [JsonProperty("urlToImage")]
        public string ImageURL { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
