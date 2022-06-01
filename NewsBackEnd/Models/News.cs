using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;

namespace NewsBackEnd.Models
{
    public class News
    {
        public int Amount { get; set; }
        public string? Title {get;set;}
        public string? SourceName { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public DateTime ReleaseDate = DateTime.Today;
        public string Search { get; set; }
        public string Imgurl { get; set; }

        public List<Article> newsArticles = new();

        public News()
        {
        }

        public News(Article news, int amount)
        {
            Amount = amount;
            Title = news.Title;
            SourceName = news.Source.Name;
            Description = news.Description;
            ReleaseDate = (DateTime)news.PublishedAt;
            Url = news.Url;
            Imgurl = news.UrlToImage;
        }
        public List<Article> GetArticlesBySearch(Languages language, DateTime date, string search)
        {
            var newsApiClient = new NewsApiClient("abdac52f05f64ef5805779553a2218e3");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = search,
                SortBy = SortBys.Popularity,
                Language = language,
                From = date
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                foreach (var article in articlesResponse.Articles)
                {
                    newsArticles.Add(article);
                }
                return newsArticles;
            }
            return null;
        }
    }
}
