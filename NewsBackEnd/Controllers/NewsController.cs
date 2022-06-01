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
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        public News news = new();
        public JsonResult GetNewsArticles(string criteria)
        {
            int amount = 1;
            List<News> newsArticles = new();
            foreach (var article in news.GetArticlesBySearch(Languages.NL, DateTime.Today, criteria))
            {
                amount += 1;
                newsArticles.Add(new News(article, amount));
            }
            //string hotArticles = JsonConvert.SerializeObject(newsArticles);

            return Json(newsArticles);
        }
    }
}