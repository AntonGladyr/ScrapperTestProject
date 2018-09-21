using System;
using System.Web;

namespace TestProject.Services
{
    public static class NewsEndpointBuilder
    {
        public const string redditApiURL      = "https://www.reddit.com";
        public const string newsApiURL        = "https://newsapi.org";
        public const string redditApiEndpoint = "/.json";
        public const string newsApiEndpoint   = "/v2/everything";
        public const string newsServiceApiKey = "16f0629667e4489092a8b6c353388c04";

        public static string GetRedditNewsURL(string afterID = "")
        {
            var builder = new UriBuilder(redditApiURL + redditApiEndpoint);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            //TODO: First request should be without "after" parameter
            query["after"] = afterID;
            builder.Query = query.ToString();
            return builder.ToString();        
        }

        public static string GetNewsApiURL(string source, string lang, string page)
        {
            var builder = new UriBuilder(newsApiURL + newsApiEndpoint);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            //TODO: Create enum for parameters
            query["sources"] = source;
            query["language"] = lang;
            query["page"] = page;
            query["apiKey"] = newsServiceApiKey;
            builder.Query = query.ToString();
            return builder.ToString();
        }
    }
}
