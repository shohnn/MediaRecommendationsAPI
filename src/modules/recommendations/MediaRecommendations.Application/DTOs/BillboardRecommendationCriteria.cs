using System;
using System.ComponentModel.DataAnnotations;

namespace MediaRecommendations.Application.DTOs
{
	public class BillboardRecommendationCriteria
	{
        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Number of screens should be at least 1.")]
        public int NumberOfScreens { get; set; }
        
    }
}

