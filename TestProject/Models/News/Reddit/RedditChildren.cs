using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestProject.Models
{
    public class RedditChildren
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public RedditNews Data { get; set; }
    }
}
