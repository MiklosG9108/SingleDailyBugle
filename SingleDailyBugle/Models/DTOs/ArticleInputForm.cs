using Microsoft.Build.Framework;

namespace SingleDailyBugle.Models.DTOs;

public class ArticleInputForm
{
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Synopsis { get; set; } = string.Empty;
    [Required]
    public string Body { get; set; } = string.Empty;
}
