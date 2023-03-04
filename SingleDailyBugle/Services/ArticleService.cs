using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;

namespace SingleDailyBugle.Services;

public class ArticleService
{
    private readonly ApplicationDbContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;
    public ArticleService(ApplicationDbContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task CreateArticleAsync(ArticleInputForm baseArticle)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(baseArticle));

        if (baseArticle.Author is not null && 
            baseArticle.Title is not null && 
            baseArticle.Synopsis is not null && 
            baseArticle.Body is not null)
        {
            _context.Articles.Add(new Article
            {
                Author = baseArticle.Author,
                Title = baseArticle.Title,
                Synopsis = baseArticle.Synopsis,
                Body = baseArticle.Body,
                CreatedAt = _dateTimeProvider.UtcNow,
                ModifiedAt = _dateTimeProvider.UtcNow,
                IsDeleted = false
            });

            _= await _context.SaveChangesAsync();
        }
        throw new EditorialException("You must fill out with words every brackets");
    }

}
