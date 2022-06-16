using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

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
    }
}
