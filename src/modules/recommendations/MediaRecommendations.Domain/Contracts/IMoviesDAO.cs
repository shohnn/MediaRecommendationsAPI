using System;
namespace MediaRecommendations.Domain.Contracts
{
	public interface IMoviesDAO
	{
		List<string> GetPopularGenres();
	}
}

