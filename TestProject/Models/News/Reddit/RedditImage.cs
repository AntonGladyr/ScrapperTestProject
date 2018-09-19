using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestProject.Models
{
    public class RedditImage
    {
        [JsonProperty("source")]
        public RedditImageSource Source { get; set; }
        //[JsonProperty("id")]
        //public string Id { get; set; }
    }
}
