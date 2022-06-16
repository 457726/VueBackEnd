using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BackEndTests
{
    [TestClass]
    public class RatingSystemTests
    {
        MockDal _mockDAL;
        [TestInitialize]
        public void NewDAL()
        {
            _mockDAL = new MockDal();
        }

        [TestMethod]
        public void AddRating()
        {
            _mockDAL.ReviewArticle("Perfect", "News", 10);

            Assert.AreEqual(1, _mockDAL.reviewModels.Count);
        }

        [TestMethod]
        public void TestAverageRating1()
        {
            _mockDAL.ReviewArticle("Ukraine War Escalated", "Ukraine is fake", 3);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "Russia!!!!", 1);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "Total bullshit", 5);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "What is this?", 4);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "Such a good article with needed information", 9);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "Best article i've read!", 10);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "I love this site!!", 7);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "Good information", 6);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "There are more important things!!", 2);
            _mockDAL.ReviewArticle("Ukraine War Escalated", "I want cheap gas!", 5);


            Assert.AreEqual(5, _mockDAL.GetAverageRating("Ukraine War Escalated"));
        }

        [TestMethod]
        public void TestAverageRating2()
        {
            _mockDAL.ReviewArticle("Tesla comes with new car", "I don't like this article", 9);
            _mockDAL.ReviewArticle("Tesla comes with new car", "What a great author", 1);

            Assert.AreEqual(5, _mockDAL.GetAverageRating("Tesla comes with new car"));
        }

        [TestMethod]
        public void FindArticle()
        {
            _mockDAL.ReviewArticle("Tesla bankrupt", "Great!", 10);
            _mockDAL.ReviewArticle("Tesla bankrupt", "What is this", 3);
            _mockDAL.ReviewArticle("Tesla bankrupt", "I like it", 7);
            _mockDAL.ReviewArticle("Olympic games will be hosted somewhere else", "Bad article", 6);
            _mockDAL.ReviewArticle("Olympic games will be hosted somewhere else", "Good", 8);

            Assert.AreEqual(3, _mockDAL.GetAllArticleReviews("Tesla bankrupt").Count);
        }

        [TestMethod]
        public void TestIfAddedArticleIsReallyThatArticle()
        {
            ReviewModel reviewModel = new ReviewModel("I don't like this article", "Tesla comes with new car", 9);

            _mockDAL.ReviewArticle("Tesla comes with new car", "I don't like this article", 9);

            Assert.AreEqual(_mockDAL.reviewModels[0].Rating, reviewModel.Rating);
            Assert.AreEqual(_mockDAL.reviewModels[0].Title, reviewModel.Title);
            Assert.AreEqual(_mockDAL.reviewModels[0].Comment, reviewModel.Comment);
        }

        [TestMethod]
        public void TestIfMultipleAddedArticlesAreReallyThoseArticles()
        {
            ReviewModel reviewModel = new ReviewModel("I don't like this article", "Tesla comes with new car", 9);
            ReviewModel reviewModel1 = new ReviewModel("I don't like war", "Ukraine War", 3);

            _mockDAL.ReviewArticle("Tesla comes with new car", "I don't like this article", 9);
            _mockDAL.ReviewArticle("Ukraine War", "I don't like war", 3);

            Assert.AreEqual(_mockDAL.reviewModels[0].Rating, reviewModel.Rating);
            Assert.AreEqual(_mockDAL.reviewModels[0].Title, reviewModel.Title);
            Assert.AreEqual(_mockDAL.reviewModels[0].Comment, reviewModel.Comment);
            Assert.AreEqual(_mockDAL.reviewModels[1].Rating, reviewModel1.Rating);
            Assert.AreEqual(_mockDAL.reviewModels[1].Title, reviewModel1.Title);
            Assert.AreEqual(_mockDAL.reviewModels[1].Comment, reviewModel1.Comment);
        }
    }
}
