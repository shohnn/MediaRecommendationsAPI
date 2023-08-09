using System;
using MediaRecommendations.Domain.Enum;

namespace MediaRecommendations.Domain.Models
{
	public class Recommendation
	{
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Genre { get; set; }
        public bool Adult { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Website { get; set; }
        public List<string> Keywords { get; set; }
        public MediaType MediaType { get; set; }
    }
}

