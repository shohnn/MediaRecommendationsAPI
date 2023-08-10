using System;
using MediaRecommendations.Domain.Contracts;
using MediaRecommendations.Domain.Models;
using RestSharp;

namespace MediaRecommendations.Infrastructure.TmdbService
{
	public class TmdbService : IMediaInformationService
	{
        private const string API_URL_ROOT = "https://api.themoviedb.org/3/discover/movie";
        private const double NUM_RESULTS_PER_PAGE = 20.0;
        RestClientOptions options;
        RestClient client;
        private const string DEFAULT_PARAMS = "include_adult=false&include_video=false&language=en-US";

        public async Task<List<Recommendation>> GetBlockBustersAsync(int BigScreens, int weeks, List<string> popularGenres)
        {
            List<Recommendation> recommendations = new List<Recommendation>();
            string withGenresParam = "&with_genres=";

            int numPages = (int)Math.Ceiling((BigScreens * weeks) / NUM_RESULTS_PER_PAGE);

            string formattedPopularGenres = GenreStorage.GetFormattedGenres(popularGenres);

            List<MovieResultDTO> requestResults = await MakeRequestWithParam(withGenresParam, numPages, formattedPopularGenres);

            requestResults.ForEach(x => x.Results
                .ForEach(y =>
                {
                    var genreId = y.GenreIds.FirstOrDefault();
                    recommendations.Add(
                        new Recommendation()
                        {
                            Title = y.Title,
                            Overview = y.Overview,
                            Genre = genreId != default ? GenreStorage.GenresById[genreId] : "Unspecified", // You might want a default genre or null check
                            Adult = y.Adult,
                            Language = y.OriginalLanguage,
                            ReleaseDate = y.ReleaseDate,
                            MediaType = Domain.Enum.MediaType.Movie
                        });
                })
            );


            return recommendations;
        }

        public async Task<List<Recommendation>> GetSmallRoomMoviesAsync(int SmallScreens, int weeks, List<string> popularGenres)
        {
            List<Recommendation> recommendations = new List<Recommendation>();

            string withoutGenresParam = "&without_genres=";

            int numPages = (int)Math.Ceiling((SmallScreens * weeks) / NUM_RESULTS_PER_PAGE);

            string formattedPopularGenres = GenreStorage.GetFormattedGenres(popularGenres);

            List<MovieResultDTO> requestResults = await MakeRequestWithParam(withoutGenresParam, numPages, formattedPopularGenres);

            requestResults.ForEach(x => x.Results
                .ForEach(y =>
                {
                    var genreId = y.GenreIds.FirstOrDefault();
                    recommendations.Add(
                        new Recommendation()
                        {
                            Title = y.Title,
                            Overview = y.Overview,
                            Genre = genreId != default ? GenreStorage.GenresById[genreId] : "Unspecified", // You might want a default genre or null check
                            Adult = y.Adult,
                            Language = y.OriginalLanguage,
                            ReleaseDate = y.ReleaseDate,
                            MediaType = Domain.Enum.MediaType.Movie
                        });
                })
            );

            return recommendations;
        }

        private async Task<List<MovieResultDTO>> MakeRequestWithParam(string param, int numPages, string popularGenres)
        {
            List<MovieResultDTO> results = new List<MovieResultDTO>();
            options = new RestClientOptions();

            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            //TODO Store private key in secrets.
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI5MGUyZDAwZjhhNTY3YTBlYzM1NWY1OTE3NGE4MzhhZCIsInN1YiI6IjY0ZDI4YWVkOTQ1ZDM2MDBhY2EwYzdjZCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.3XeJ5my1tGvnYdVEPNuOGXgAqlKv0bsTCdyZ_WwhXKs");

            string genreParam = param + popularGenres;

            for (int i = 1; i <= numPages; i++)
            {
                string pageAndSortParams = $"&page={i}&sort_by=popularity.desc";
                string finalUrl = API_URL_ROOT + "?" + DEFAULT_PARAMS + pageAndSortParams + genreParam;
                options.BaseUrl = new Uri(finalUrl);
                client = new RestClient(options);

                var response = await client.GetAsync(request);

                MovieResultDTO movieResult = MovieResultDTO.DeserializeFromJson(response.Content);
                Console.WriteLine("{0}", response.Content);
                results.Add(movieResult);
            }

            return results;
        }
    }
}

