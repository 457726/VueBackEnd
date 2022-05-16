using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;

namespace NewsBackEnd.Models
{
    public class ArticleBySearch
    {
        public List<Article> newsArticles = new();
        public List<Article> GetArticlesBySearch(string search)
        {
            var newsApiClient = new NewsApiClient("abdac52f05f64ef5805779553a2218e3");
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = search,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2018, 1, 25)
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
