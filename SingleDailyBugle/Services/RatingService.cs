using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;

namespace SingleDailyBugle.Services;

public class RatingService : IRatingService
{
    private readonly ApplicationDbContext _context;
    private readonly IArticleService _articleService;
    public RatingService(ApplicationDbContext context, IArticleService articleService)
    {
        _context = context;
        _articleService = articleService;
    }
    public async Task CreateRatingAsync(int articleId, RatingInputForm rating)
    {
        ArgumentNullException.ThrowIfNull(rating);

        if (rating.Value < 1 || rating.Value > 5)
        {
            throw new EditorialException("Rate our articles between 1 and 5");
        }

        var currentArticle = await _articleService.GetArticleByIdAsync(articleId);

        Rating currentRating = new Rating
        {
            Value = rating.Value,
            Article = currentArticle,
        };

        _context.Ratings.Add(currentRating);

        _ = await _context.SaveChangesAsync();
    }
}
