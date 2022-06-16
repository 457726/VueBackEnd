using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBackEnd.DataAccess;
using NewsBackEnd.Models;
using System;
using System.Collections.Generic;

namespace NewsBackEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewController : Controller
    {
        RatingDataAccess ratingDataAccess = new();

        [HttpPost]
        public string Rate([FromBody] ReviewModel review)
        {
            if (review != null)
            {
                try
                {
                    ratingDataAccess.RateArticle(review.Comment, review.Title, review.Rating);
                    return "perfect";
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return "";
        }
        [HttpGet]
        public JsonResult GetReviews(string title)
        {
            List<ReviewModel> reviews = new();

            foreach (var review in ratingDataAccess.GetArticleReviews(title))
            {
                reviews.Add(review);
            }

            return Json(reviews);
        }

        [HttpGet]
        public JsonResult GetGrade(string title)
        {
            return Json(ratingDataAccess.GetGrades(title));
        }
    }
}
