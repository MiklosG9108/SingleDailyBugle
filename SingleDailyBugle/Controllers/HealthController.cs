using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace SingleDailyBugle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("Ping")]
        public ActionResult<string> Ping()
        {
            return Ok("Pong");
        }

        [HttpGet("Journalist")]
        [Authorize(Roles = "Journalist")]
        public ActionResult<string> JournalistAsync()
        {
            return Ok("This is for Journalist only.");
        }

        [HttpGet("Reader")]
        [Authorize(Roles = "Reader")]
        public ActionResult<string> ReaderAsync()
        {
            return Ok("This is for Reader only.");
        }

        [HttpGet("Together")]
        [Authorize(Roles = "Journalist, Reader")]
        public ActionResult<string> TogetherAsync()
        {
            return Ok("This is for both of you only.");
        }
    }
}
