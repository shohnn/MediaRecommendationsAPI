using System;
using Newtonsoft.Json;

namespace MediaRecommendations.Infrastructure.TmdbService
{
	public class MovieResultDTO
	{
        public int Page { get; set; }
        public List<MovieDetail> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }

        public static MovieResultDTO DeserializeFromJson(string jsonString)
        {
            return JsonConvert.DeserializeObject<MovieResultDTO>(jsonString);
        }
    }
}

