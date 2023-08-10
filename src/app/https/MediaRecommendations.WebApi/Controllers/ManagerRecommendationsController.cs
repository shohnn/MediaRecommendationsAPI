using System;
using MediaRecommendations.Application.DTOs;
using MediaRecommendations.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace MediaRecommendations.WebApi.Controllers
{
    [ApiController]
    [Route("manager/recommendations")]
    public class ManagerRecommendationsController : ViewerRecommendationsController
    {
        readonly GetIntelligentBillboard _getintelligentBillboard;


		public ManagerRecommendationsController(GetIntelligentBillboard getIntelligentBillboard)
        {
            _getintelligentBillboard = getIntelligentBillboard;
        }

        [HttpGet("billboard")]
        public async Task<IActionResult> GetBillboardRecommendations(BillboardRecommendationCriteria criteria)
        {
            throw new NotImplementedException();
        }

        [HttpGet("intelligent-billboard")]
        public async Task<IActionResult> GetIntelligentBillboardRecommendations(IntelligentBillboardRecommendationCriteria criteria)
        {
            // Check if the criteria is less than one week
            if ((criteria.PeriodEnd - criteria.PeriodStart).TotalDays < 7)
            {
                return BadRequest("The specified period should be at least one week.");
            }

            var recommendations = await _getintelligentBillboard.Get(criteria);
            return Ok(recommendations);
        }
    }
}

