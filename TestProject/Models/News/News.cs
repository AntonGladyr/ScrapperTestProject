using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestProject.Models
{
    public class News
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Permalink { get; set; }
        public string ImageURL { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ID { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string CommentsNumber { get; set; }
        public string Score { get; set; }
        public string SubredditName { get; set; }

        public News(
            string author,
            string title,
            string permalink,
            string imageURL,
            DateTime releaseDate,
            string id,
            string content,
            string description,
            string commentsNumber,
            string score,
            string subredditName
        )
        {
            this.Author = author;
            this.Title = title;
            this.Permalink = permalink;
            this.ImageURL = imageURL;
            this.ReleaseDate = releaseDate;
            this.ID = id;
            this.Content = content;
            this.Description = description;
            this.CommentsNumber = commentsNumber;
            this.Score = score;
            this.SubredditName = subredditName;
        }
    }
}
