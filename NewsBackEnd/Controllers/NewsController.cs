using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using NewsBackEnd.Models;

namespace NewsBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        public News news = new();
        public JsonResult GetNewsArticles(string criteria)
        {
            List<News> newsArticles = new();
            foreach (var article in news.GetArticlesBySearch(Languages.EN,new DateTime(2022, 05, 16), criteria))
            {
                newsArticles.Add(new News(article));
            }
            string hotArticles = JsonConvert.SerializeObject(new
            {
                newsArticles
            });
            return Json(hotArticles);
        }
    }
}