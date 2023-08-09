using System;
using System.Linq;
using System.Text;

namespace MediaRecommendations.Infrastructure.TmdbService
{
    public static class GenreStorage
    {
        public static Dictionary<int, string> GenresById { get; } = new Dictionary<int, string>
        {
            {28, "Action"},
            {12, "Adventure"},
            {16, "Animation"},
            {35, "Comedy"},
            {80, "Crime"},
            {99, "Documentary"},
            {18, "Drama"},
            {10751, "Family"},
            {14, "Fantasy"},
            {36, "History"},
            {27, "Horror"},
            {10402, "Music"},
            {9648, "Mystery"},
            {10749, "Romance"},
            {878, "Science Fiction"},
            {10770, "TV Movie"},
            {53, "Thriller"},
            {10752, "War"},
            {37, "Western"}
        };

        // Based on https://fivethirtyeight.com/features/the-11-defining-features-of-the-summer-blockbuster/
        public static string GetBlockBusterGenres()
        {
            string orOperand = "%7C";
            StringBuilder sb = new StringBuilder();
            sb.Append(28);
            sb.Append(orOperand);
            sb.Append(12);
            sb.Append(orOperand);
            sb.Append(53);
            sb.Append(orOperand);
            sb.Append(35);
            sb.Append(orOperand);
            sb.Append(18);

            return sb.ToString();
        }
    }
}

