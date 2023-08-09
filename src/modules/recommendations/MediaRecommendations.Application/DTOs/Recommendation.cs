using System;
namespace MediaRecommendations.Application.DTOs;
public class Recommendation
{
    public string Title { get; set; }
    public string Overview { get; set; }
    public string Genre { get; set; }
    public string Adult { get; set; }
    public string Language { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Website { get; set; }
    public List<string> Keywords { get; set; }
    public string MediaType { get; set; }

    public static Recommendation FromDomain(Domain.Models.Recommendation recommendation)
    {
        return new Recommendation()
        {
            Title = recommendation.Title,
            Overview = recommendation.Overview,
            Genre = recommendation.Genre,
            Adult = recommendation.Adult.ToString(),
            Language = recommendation.Language,
            ReleaseDate = recommendation.ReleaseDate,
            Website = recommendation.Website,
            Keywords = recommendation.Keywords,
            MediaType = recommendation.MediaType.ToString()
        };
    }
}