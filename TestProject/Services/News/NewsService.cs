using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services
{
    public class NewsService
    {
        public async Task<NewsData> GetNewsListAsync(
            string redditAfterID = "",
            string apiServicePage = "1")
        {
            //TODO: Create enum for news vebservices
            var redditNewsTask = GetRedditNewsAsync(redditAfterID);
            var googleNewsTask = GetApiServiceNewsAsync("google-news", apiServicePage);
            var bbcNewsTask = GetApiServiceNewsAsync("bbc-news", apiServicePage);
            await Task.WhenAll(redditNewsTask, googleNewsTask, bbcNewsTask);

            List<News> newsList = redditNewsTask.Result.Children.ToList().ConvertAll(
                x => new News(
                    x.Data.Author,
                    x.Data.Title,
                    "reddit.com" + x.Data.Permalink,
                    x.Data.Preview != null ? x.Data.Preview.Images.First().Source.Url : null,
                    //x.ReleaseDate,
                    DateTime.Now,
                    x.Data.ID,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    String.Empty,
                    x.Data.SubredditName
                )
            ).Union(googleNewsTask.Result.ToList().ConvertAll(
                y => new News(
                    y.Author,
                    y.Title,
                    y.Permalink,
                    y.ImageURL,
                    y.ReleaseDate,
                    String.Empty,
                    y.Content,
                    y.Description,
                    String.Empty,
                    String.Empty,
                    String.Empty
                )
            )).Union(bbcNewsTask.Result.ToList().ConvertAll(
                r => new News(
                    r.Author,
                    r.Title,
                    r.Permalink,
                    r.ImageURL,
                    r.ReleaseDate,
                    String.Empty,
                    r.Content,
                    r.Description,
                    String.Empty,
                    String.Empty,
                    String.Empty
                 ))
            ).ToList();
            NewsData newsData = new NewsData(newsList, redditNewsTask.Result.After, apiServicePage);
            return newsData;
        }

        private async Task<RedditData> GetRedditNewsAsync(string redditAfterID)
        {
            string url = NewsEndpointBuilder.GetRedditNewsURL(redditAfterID);
            Console.WriteLine("GetRedditNewsAsync");
            Console.WriteLine(url);
            var response = await NetwrokService.Instance.GetRequestResultAsync(url);
            JObject dataResult = JObject.Parse(response);
            JToken result = dataResult["data"];
            RedditData redditData = result.ToObject<RedditData>();
            return redditData;
        }

        private async Task<IList<ApiServiceNews>> GetApiServiceNewsAsync(string sources, string apiServicePage)
        {
            //TODO: Add enum for languages and sources
            string url = NewsEndpointBuilder.GetNewsApiURL(sources, "en", apiServicePage);
            Console.WriteLine(url);
            var response = await NetwrokService.Instance.GetRequestResultAsync(url);
            JObject dataResult = JObject.Parse(response);

            // get JSON result objects into a list
            IList<JToken> results = dataResult["articles"].Children().ToList();
            NewsSerializer<ApiServiceNews> googleNewsList = new NewsSerializer<ApiServiceNews>();
            return googleNewsList.SerializeNewsList(results);
        }
    }
}
