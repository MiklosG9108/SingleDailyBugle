using System.ComponentModel.DataAnnotations;

namespace SingleDailyBugle.Models
{
    public class Rating
    {
        public int Id { get; set; }
        
        [Required, Range(0, 5)]
        public int Value { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; } = default!;
    }
}
