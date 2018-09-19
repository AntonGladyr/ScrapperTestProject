using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestProject.Models
{
    public class RedditPreview
    {
        [JsonProperty("images")]
        public RedditImage[] Images { get; set; }
    }
}
