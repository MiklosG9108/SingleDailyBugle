using Microsoft.Build.Framework;

namespace SingleDailyBugle.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; } = default!;
    }
}
