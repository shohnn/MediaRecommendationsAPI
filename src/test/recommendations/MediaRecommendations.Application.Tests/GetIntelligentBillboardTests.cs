using MediaRecommendations.Application.DTOs;
using MediaRecommendations.Application.UseCases;
using MediaRecommendations.Domain.Contracts;
using Moq;
using Xunit;

namespace MediaRecommendations.Application.Tests;

public class GetIntelligentBillboardTest
{
    private readonly Mock<IMoviesDAO> _moviesDaoMock;
    private readonly Mock<IMediaInformationService> _mediaInformationServiceMock;
    private readonly GetIntelligentBillboard _yourClassInstance; 

    public GetIntelligentBillboardTest()
    {
        _moviesDaoMock = new Mock<IMoviesDAO>();
        _mediaInformationServiceMock = new Mock<IMediaInformationService>();
        _yourClassInstance = new GetIntelligentBillboard(_mediaInformationServiceMock.Object, _moviesDaoMock.Object); 
    }

    [Fact]
    public async Task Get_ShouldHandleWhenNotEnoughBigRoomRecommendationsAsync()
    {
        // Arrange
        var request = new IntelligentBillboardRecommendationCriteria
        {
            IsBasedOnCitySuccess = true,
            PeriodStart = DateTime.Now,
            PeriodEnd = DateTime.Now.AddDays(14),
            NumberOfBigRooms = 5,
            NumberOfSmallRooms = 2
        };

        _moviesDaoMock.Setup(d => d.GetPopularGenres()).Returns(new List<string> { "Action", "Comedy" });

        _mediaInformationServiceMock.Setup(s => s.GetBlockBustersAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>()))
                                    .ReturnsAsync(new List<Domain.Models.Recommendation>
                                    {
                                        new Domain.Models.Recommendation { Title = "Movie 1" },
                                        new Domain.Models.Recommendation { Title = "Movie 2" }
                                    }); // Only two movies for big rooms.

        _mediaInformationServiceMock.Setup(s => s.GetSmallRoomMoviesAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<string>>()))
                                    .ReturnsAsync(new List<Domain.Models.Recommendation>
                                    {
                                        new Domain.Models.Recommendation { Title = "Small Movie 1" },
                                        new Domain.Models.Recommendation { Title = "Small Movie 2" }
                                    });

        // Act
        var result = await _yourClassInstance.Get(request);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Recommendations.First().BigRoomRecommendations.Count < request.NumberOfBigRooms);
    }
}
