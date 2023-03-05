using System.ComponentModel.DataAnnotations;

namespace SingleDailyBugle.Models.ViewModels;

public class ArticleListItem
{
    public int Id { get; set; }
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Synopsis { get; set; } = string.Empty;

    public int NumberOfComments { get; set; }
}
