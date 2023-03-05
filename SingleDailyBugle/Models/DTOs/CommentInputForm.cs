using Microsoft.Build.Framework;

namespace SingleDailyBugle.Models.DTOs
{
    public class CommentInputForm
    {
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;
    }
}
