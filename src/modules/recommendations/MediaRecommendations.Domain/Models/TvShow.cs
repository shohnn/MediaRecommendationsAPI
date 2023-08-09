using System;
namespace MediaRecommendations.Domain.Models
{
	public class TvShow : Recommendation
	{
        public int SeasonsCount { get; set; }
        public int EpisodesCount { get; set; }
        public bool IsConcluded { get; set; }
    }
}

