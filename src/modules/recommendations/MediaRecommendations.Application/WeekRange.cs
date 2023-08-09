using System;
namespace MediaRecommendations.Application
{
    public class WeekRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        public static List<WeekRange> GetWeekRanges(DateTime startDate, DateTime endDate)
        {
            List<WeekRange> weekRanges = new List<WeekRange>();

            // Adjust the start date to be the start of the next week if it's not already Monday
            while (startDate.DayOfWeek != DayOfWeek.Monday && startDate <= endDate)
            {
                startDate = startDate.AddDays(1);
            }

            // Loop to find each week's start and end dates
            while (startDate < endDate)
            {
                DateTime weekEnd = startDate.AddDays(6); // adding 6 gets to Sunday
                if (weekEnd > endDate)
                {
                    weekEnd = endDate;
                }
                weekRanges.Add(new WeekRange { Start = startDate, End = weekEnd });

                startDate = startDate.AddDays(7); // move to the next week's Monday
            }

            return weekRanges;
        }
    }
}

