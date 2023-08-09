using System;
using MediaRecommendations.Domain.Enum;
using MediaRecommendations.Domain.Models;

namespace MediaRecommendations.Domain.Contracts
{
    public interface IMediaInformationService
    {

        Task<List<Recommendation>> GetBlockBustersAsync(int BigScreens, int weeks);

        Task<List<Recommendation>> GetSmallRoomMoviesAsync(int SmallScreens, int weeks);
    }
}

