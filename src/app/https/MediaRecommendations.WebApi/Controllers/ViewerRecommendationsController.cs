using System;
using MediaRecommendations.Application.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace MediaRecommendations.WebApi.Controllers
{
    [ApiController]
    [Route("viewer/recommendations")]
    public class ViewerRecommendationsController : Controller
	{
        

        public ViewerRecommendationsController()
        {
        }

        [HttpGet("movies")]
        public virtual async Task<IActionResult> GetMovieRecommendations(MovieRecommendationCriteria criteria)
        {
            throw new NotImplementedException();
        }

        [HttpGet("tvshows")]
        public virtual async Task<IActionResult> GetTvShowsRecommendations(TvShowRecommendationCriteria criteria)
        {
            throw new NotImplementedException();
        }

        [HttpGet("documentaries")]
        public virtual async Task<IActionResult> GetDocumentaryRecommendations(DocumentaryRecommendationCriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}

