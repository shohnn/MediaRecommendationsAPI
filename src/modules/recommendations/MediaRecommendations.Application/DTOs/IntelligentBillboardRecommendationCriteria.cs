using System;
using System.ComponentModel.DataAnnotations;

namespace MediaRecommendations.Application.DTOs
{
	public class IntelligentBillboardRecommendationCriteria
	{
        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number of big rooms should be at least 1.")]
        public int NumberOfBigRooms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number of small rooms should be non-negative.")]
        public int NumberOfSmallRooms { get; set; }

        public bool IsBasedOnCitySuccess { get; set; }
    }
}

