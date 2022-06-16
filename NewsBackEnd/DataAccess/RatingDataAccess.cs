using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NewsBackEnd.Models;
using System.Collections.Generic;

namespace NewsBackEnd.DataAccess
{
    public class RatingDataAccess
    {
        public RatingDataAccess()
        {

        }

        private readonly string connectionString = "Server = studmysql01.fhict.local; Uid=dbi457726;Database=dbi457726;Pwd=Banaan12;";
        public void RateArticle(string comment, string title, int rating)
        {

            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($"INSERT INTO `review`(`Title`, `Rating`, `Comment`) VALUES (@title, @rating, @comment)", con);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@comment", comment);

            MySqlDataReader reader = cmd.ExecuteReader();
        }
        [HttpGet]
        public List<ReviewModel> GetArticleReviews(string title)
        {
            List<ReviewModel> articleReviews = new();
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($" SELECT `Comment`, `Rating` FROM `review` WHERE `Title` = @title", con);
            cmd.Parameters.AddWithValue("@title", title);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ReviewModel rating = new();
                rating.Comment = reader["Comment"].ToString();
                rating.Rating = int.Parse(reader["Rating"].ToString());
                articleReviews.Add(rating);
            }
            reader.Close();

            return articleReviews;
        }

        [HttpGet]
        public int GetGrades(string title)
        {
            List<int> grades = new();
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($" SELECT `Rating` FROM `review` WHERE `Title` = @title", con);
            cmd.Parameters.AddWithValue("@title", title);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int articleGrade;
                articleGrade = int.Parse(reader["Rating"].ToString());
                grades.Add(articleGrade);
            }
            reader.Close();

            int grade = 0;
            int i = 0;
            foreach (var rating in grades)
            {
                i++;
                grade += rating;
            }
            return grade;
        }
    }
}
