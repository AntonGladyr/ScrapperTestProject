﻿using System;
using Newtonsoft.Json;

namespace TestProject.Models
{
    public class RedditImageSource
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
