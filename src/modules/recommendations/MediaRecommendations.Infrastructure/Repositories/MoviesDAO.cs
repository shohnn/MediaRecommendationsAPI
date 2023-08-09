using System;
using System.Data.SqlClient;
using MediaRecommendations.Domain.Contracts;

namespace MediaRecommendations.Infrastructure.Repositories
{
	public class MoviesDAO :IMoviesDAO
	{
        private readonly string _connectionString = "Server=tcp:beezybetest.database.windows.net,1433;Initial Catalog=beezycinema;Persist Security Info=False;User Id=betestuser;Password=ReadOnly!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public MoviesDAO()
		{
		}

        public List<string> GetPopularGenres()
        {
            var genres = new List<string>();

            var query = @"
            SELECT g.Name
            FROM dbo.Movie m
            INNER JOIN dbo.Session s ON m.Id = s.MovieId
            INNER JOIN dbo.MovieGenre mg ON m.Id = mg.MovieId
            INNER JOIN dbo.Genre g ON mg.GenreId = g.Id
            GROUP BY g.Name
            ORDER BY SUM(s.SeatsSold) DESC";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genres.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return genres;
        }
    }
}

