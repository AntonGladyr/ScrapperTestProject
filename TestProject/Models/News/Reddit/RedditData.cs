using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestProject.Models
{
    public class RedditData
    {
        [JsonProperty("children")]
        public List<RedditChildren> Children { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }
}
