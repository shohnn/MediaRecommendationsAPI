using System;
using System.Linq;
using MediaRecommendations.Application.DTOs;
using MediaRecommendations.Domain.Contracts;

namespace MediaRecommendations.Application.UseCases
{
	public class GetIntelligentBillboard
	{
		IMediaInformationService _mediaInformationService;
        IMoviesDAO _moviesDao;

		public GetIntelligentBillboard(IMediaInformationService mediaInformationService, IMoviesDAO moviesDAO)
		{
			_mediaInformationService = mediaInformationService ?? throw new ArgumentException(nameof(mediaInformationService));
            _moviesDao = moviesDAO ?? throw new ArgumentException(nameof(moviesDAO));
        }

        public async Task<IntelligentBillboard> Get(IntelligentBillboardRecommendationCriteria request)
		{
			IntelligentBillboard intelligentBillboard = new IntelligentBillboard();
            List<WeeklyRecommendation> recommendations = new List<WeeklyRecommendation>();
            List<WeekRange> weekRanges = WeekRange.GetWeekRanges(request.PeriodStart, request.PeriodEnd);
            List<string> popularGenres = new();

            int weeks = weekRanges.Count;

            if (request.IsBasedOnCitySuccess)
            {
                popularGenres = _moviesDao.GetPopularGenres();
                List<Domain.Models.Recommendation> bigScreenRecommendations = await _mediaInformationService.GetBlockBustersAsync(request.NumberOfBigRooms, weeks, popularGenres);

                List<Domain.Models.Recommendation> smallScreenRecommendations = await _mediaInformationService.GetSmallRoomMoviesAsync(request.NumberOfSmallRooms, weeks, popularGenres);

                foreach (WeekRange weekRange in weekRanges)
                {
                    WeeklyRecommendation weekRecommendation = new WeeklyRecommendation();
                    weekRecommendation.WeekStart = weekRange.Start;
                    weekRecommendation.WeekEnd = weekRange.End;

                    for (int i = 0; i < request.NumberOfBigRooms; i++)
                    {
                        if (bigScreenRecommendations.Any())
                        {
                            Domain.Models.Recommendation currentRecommendation = bigScreenRecommendations.First();
                            weekRecommendation.BigRoomRecommendations.Add(Recommendation.FromDomain(currentRecommendation));
                            bigScreenRecommendations.RemoveAll(x => x.Title == currentRecommendation.Title);
                        }
                        else
                        {
                            // Optionally handle the situation where there aren't enough recommendations for the rooms.
                            break;
                        }
                    }

                    for (int j = 0; j < request.NumberOfSmallRooms; j++)
                    {
                        if (smallScreenRecommendations.Any())
                        {
                            Domain.Models.Recommendation currentRecommendation = smallScreenRecommendations.First();
                            weekRecommendation.SmallRoomRecommendations.Add(Recommendation.FromDomain(currentRecommendation));
                            smallScreenRecommendations.RemoveAll(x => x.Title == currentRecommendation.Title);
                        }
                        else
                        {
                            // Optionally handle the situation where there aren't enough recommendations for the rooms.
                            break;
                        }
                    }

                    recommendations.Add(weekRecommendation);
                }

                intelligentBillboard.Recommendations = recommendations;
            }

            return intelligentBillboard;
		}
    }
}

