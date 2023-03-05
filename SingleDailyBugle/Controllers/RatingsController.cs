using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;
using SingleDailyBugle.Services;

namespace SingleDailyBugle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        
        [HttpPost(nameof(PostRating))]
        public async Task<ActionResult> PostRating(int articleId, RatingInputForm rating)
        {
            await _ratingService.CreateRatingAsync(articleId, rating);

            return Ok();
        }

    }
}
