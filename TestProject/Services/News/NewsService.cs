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
        public async Task<IList<News>> GetNewsListAsync()
        {
            var redditNewsTask = GetRedditNewsAsync();
            var googleNewsTask = GetApiServiceNewsAsync("google-news");
            var bbcNewsTask = GetApiServiceNewsAsync("bbc-news");
            await Task.WhenAll(redditNewsTask, googleNewsTask, bbcNewsTask);

            Console.WriteLine("Hello world");
            Console.WriteLine(redditNewsTask.Result.Children.First().Data.Author);
            List<News> newsList = redditNewsTask.Result.Children.ToList().ConvertAll(
                x => new News(
                    x.Data.Author,
                    x.Data.Title,
                    x.Data.Permalink,
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
            return newsList;
        }

        private async Task<RedditData> GetRedditNewsAsync()
        {
            string url = NewsEndpointBuilder.GetRedditNewsURL();
            var response = await NetwrokService.Instance.GetRequestResultAsync(url);
            JObject dataResult = JObject.Parse(response);
            JToken result = dataResult["data"];
            RedditData redditData = result.ToObject<RedditData>();
            return redditData;
        }

        private async Task<IList<ApiServiceNews>> GetApiServiceNewsAsync(string sources)
        {
            string url = NewsEndpointBuilder.GetNewsApiURL(sources, "en", "1");
            var response = await NetwrokService.Instance.GetRequestResultAsync(url);
            JObject dataResult = JObject.Parse(response);

            // get JSON result objects into a list
            IList<JToken> results = dataResult["articles"].Children().ToList();
            NewsSerializer<ApiServiceNews> googleNewsList = new NewsSerializer<ApiServiceNews>();
            return googleNewsList.SerializeNewsList(results);
        }
    }
}
