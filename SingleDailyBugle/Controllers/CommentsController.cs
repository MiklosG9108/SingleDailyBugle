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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost(nameof(PostComment))]
        public async Task<ActionResult<CommentInputForm>> PostComment(int articleId, CommentInputForm comment)
        {
            await _commentService.CreateCommentAsync(articleId, comment);

            return Ok();
        }


    }
}
