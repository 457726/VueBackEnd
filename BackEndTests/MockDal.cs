using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndTests
{
    public class MockDal
    {
        public List<ReviewModel> reviewModels = new List<ReviewModel>();
        public void ReviewArticle(string title, string comment, int grade)
        {
            reviewModels.Add(new ReviewModel(comment, title, grade));
        }

        public List<ReviewModel> GetAllArticleReviews(string title)
        {
            ReviewModel[] ratings = reviewModels.FindAll(_title => _title.Title == title).ToArray();
            List<ReviewModel> articleReviews = new List<ReviewModel>();
            foreach (var review in ratings)
            {
                articleReviews.Add(review);
            }

            return articleReviews;
        }

        public int GetAverageRating(string title)
        {
            ReviewModel[] reviews = reviewModels.FindAll(_title => _title.Title == title).ToArray();
            List<int> ratings = new List<int>();
            int i = 0;
            int allratingscombined = 0;
            foreach (var rating in reviews)
            {
                i++;
                allratingscombined += rating.Rating;
            }
            int averageGrade = allratingscombined/i;
            return averageGrade;
        }
    }
}
