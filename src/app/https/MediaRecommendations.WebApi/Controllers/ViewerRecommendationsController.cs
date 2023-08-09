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

        //[HttpGet("movies")]
        //public virtual async Task<IActionResult> GetMovieRecommendations(MovieRecommendationCriteria criteria)
        //{
        //    var recommendations = await _recommendationService.GetRecommendationsForViewersAsync(criteria);
        //    return Ok(recommendations);
        //}

        //[HttpGet("tvshows")]
        //public virtual async Task<IActionResult> GetTvShowsRecommendations(MovieRecommendationCriteria criteria)
        //{
        //    var recommendations = await _recommendationService.GetRecommendationsForViewersAsync(criteria);
        //    return Ok(recommendations);
        //}

        //[HttpGet("documentaries")]
        //public virtual async Task<IActionResult> GetMovieRecommendations(MovieRecommendationCriteria criteria)
        //{
        //    var recommendations = await _recommendationService.GetRecommendationsForViewersAsync(criteria);
        //    return Ok(recommendations);
        //}
    }
}

