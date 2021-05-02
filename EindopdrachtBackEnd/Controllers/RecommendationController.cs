using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EindopdrachtBackEnd.DTO;
using EindopdrachtBackEnd.Models;
using EindopdrachtBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace EindopdrachtBackEnd.Controllers
{

    [Route("api")]
    public class RecommendationController: ControllerBase
    {

        private readonly IRecommendationService _recommendationService;
        private readonly ILogger<RecommendationController> _logger;

        public RecommendationController(ILogger<RecommendationController> logger,IRecommendationService recommendationService)
        {
            _logger = logger;
            _recommendationService = recommendationService;
        }

        // GET RECOMMENDATION WITH A SPECIFIC SCORE

        [HttpGet]
        [Route("Recommendation/{score}")]
        public ActionResult<string> GetRecommendation(decimal score)
        {
            try{
                return new OkObjectResult(_recommendationService.Recommendation(score));
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }
        
    }
}
