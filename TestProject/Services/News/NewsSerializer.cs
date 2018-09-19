using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TestProject.Services
{
    public class NewsSerializer<T>
    {
        public IList<T> SerializeNewsList(IList<JToken> results)
        {
            IList<T> newsList = new List<T>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                T news = result.ToObject<T>();
                newsList.Add(news);
            }
            return newsList;
        }
    }
}
