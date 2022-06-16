using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBackEnd.DataAccess;
using NewsBackEnd.Models;
using System;

namespace NewsBackEnd.Controllers
{
    [Route("api/[controller]")]
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
    }
}
