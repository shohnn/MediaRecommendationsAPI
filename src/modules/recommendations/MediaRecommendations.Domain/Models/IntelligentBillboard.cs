using System;
namespace MediaRecommendations.Domain.Models
{
	public class IntelligentBillboard
	{
        public List<WeeklyRecommendations> Recommendations { get; set; }

        public class WeeklyRecommendations
        {
            public DateTime WeekStart { get; set; }
            public DateTime WeekEnd { get; set; }
            public List<Recommendation> BigRoomRecommendations { get; set; }
            public List<Recommendation> SmallRoomRecommendations { get; set; }
        }
    }
}

