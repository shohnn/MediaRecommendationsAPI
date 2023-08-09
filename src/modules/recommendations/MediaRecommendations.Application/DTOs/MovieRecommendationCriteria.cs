using System;
namespace MediaRecommendations.Application.DTOs
{
	public class MovieRecommendationCriteria
	{
        public List<string> Keywords { get; set; }
        public List<string> Genres { get; set; }
        public bool Adult { get; set; }  // Only for Theater managers
        public DateTime? UpcomingPeriodTo { get; set; }
    }
}   

