using System;
namespace MediaRecommendations.Application.DTOs
{
	public class TvShowRecommendationCriteria
	{
        public List<string> Keywords { get; set; }
        public List<string> Genres { get; set; }
    }
}

