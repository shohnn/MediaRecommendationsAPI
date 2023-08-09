using System;
namespace MediaRecommendations.Application.DTOs
{
	public class IntelligentBillboard
	{
        public List<WeeklyRecommendation> Recommendations { get; set; }


        public IntelligentBillboard FromDomain(Domain.Models.IntelligentBillboard billboard)
        {
            return new IntelligentBillboard()
            {

            };
        }
    }
}

