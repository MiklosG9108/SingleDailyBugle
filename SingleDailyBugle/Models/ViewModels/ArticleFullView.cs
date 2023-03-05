using System.ComponentModel.DataAnnotations;

namespace SingleDailyBugle.Models.ViewModels
{
    public class ArticleFullView
    {
        public int Id { get; set; }
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Synopsis { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public List<string> Comments { get; set; } = new();
    }
}
