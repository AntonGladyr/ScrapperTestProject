using System;
using System.Collections.Generic;
namespace TestProject.Models
{
    public class NewsData
    {
        public string RedditAfterID { get; set; }
        public string NewsServicePage { get; set; }
        public IList<News> NewsList { get; set; }

        public NewsData(
            IList<News> newsList,
            string redditAfterID,
            string newsServicePage
        ) {
            this.NewsList = newsList;
            this.RedditAfterID = redditAfterID;
            this.NewsServicePage = newsServicePage;
    }
    }
}
