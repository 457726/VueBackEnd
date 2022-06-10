using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using NewsBackEnd.Models;
using System.Web;

namespace NewsBackEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : Controller
    {
        public News news = new();
        [HttpGet]
        public JsonResult GetNewsArticles(string criteria)
        {
            int amount = 1;
            List<News> newsArticles = new();
            foreach (var article in news.GetArticlesBySearch(Languages.NL, DateTime.Today, criteria))
            {
                amount += 1;
                newsArticles.Add(new News(article, amount));
            }
            return Json(newsArticles);
        }

        [HttpGet]
        public JsonResult GetHotNewsArticles()
        {
            int amount = 1;
            List<News> newsArticles = new();
            foreach (var article in news.GetPopularNews())
            {
                amount += 1;
                newsArticles.Add(new News(article, amount));
            }
            return Json(newsArticles);
        }
        [HttpGet]
        public JsonResult GetCoronaNewsArticles()
        {
            int amount = 1;
            List<News> newsArticles = new();
            foreach (var article in news.GetCoronaNews())
            {
                amount += 1;
                newsArticles.Add(new News(article, amount));
            }
            return Json(newsArticles);
        }
        [HttpGet]
        public JsonResult GetWarNewsArticles()
        {
            int amount = 1;
            List<News> newsArticles = new();
            foreach (var article in news.GetWarNews())
            {
                amount += 1;
                newsArticles.Add(new News(article, amount));
            }
            return Json(newsArticles);
        }
        [HttpGet]
        public JsonResult GetSportNewsArticles()
        {
            int amount = 1;
            List<News> newsArticles = new();
            foreach (var article in news.GetSportsNews())
            {
                amount += 1;
                newsArticles.Add(new News(article, amount));
            }
            return Json(newsArticles);
        }
    }
}