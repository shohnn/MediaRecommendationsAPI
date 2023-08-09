using System;
namespace MediaRecommendations.Application.DTOs
{
    public class WeeklyRecommendation
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
        public List<Recommendation> BigRoomRecommendations { get; set; }
        public List<Recommendation> SmallRoomRecommendations { get; set; }

        public WeeklyRecommendation()
        {
            BigRoomRecommendations = new List<Recommendation>();
            SmallRoomRecommendations = new List<Recommendation>();
        }
    }
}

