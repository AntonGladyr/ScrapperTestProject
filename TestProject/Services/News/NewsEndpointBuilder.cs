using System;
using System.Web;

namespace TestProject.Services
{
    public static class NewsEndpointBuilder
    {
        public const string redditApiURL = "https://www.reddit.com";
        public const string newsApiURL   = "https://newsapi.org";
        public const string apiKey = "16f0629667e4489092a8b6c353388c04";

        public static string GetRedditNewsURL(string afterID = "")
        {
            var builder = new UriBuilder(redditApiURL + "/.json");
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["after"] = afterID;
            builder.Query = query.ToString();
            return builder.ToString();        
        }

        public static string GetNewsApiURL(string source, string lang, string page)
        {
            var builder = new UriBuilder(newsApiURL + "/v2/everything");
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["sources"] = source;
            query["language"] = lang;
            query["page"] = page;
            query["apiKey"] = apiKey;
            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
