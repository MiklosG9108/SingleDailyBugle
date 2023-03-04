using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;
using SingleDailyBugle.Models.ViewModels;

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

    public async Task<IEnumerable<ArticleListItem>> GetAllArticlesAsync()
    {
        List<Article> articles = await GetAllArticles();
        IEnumerable<ArticleListItem> listedArticles = GetArticleListItem(articles);
        return listedArticles;
    }

    public async Task<Article> GetArticleByIdAsync(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        return article;
    }

    public async Task<Article> ModifyArticleAsync(int id, ArticleInputForm modifiedArticle)
    {
        var article = await GetArticleByIdAsync(id);
        if (article == null)
        {
            throw new EditorialException($"There is no article with this id: {id}.");
        }

        if ((!article.Author.Equals(modifiedArticle.Author)) && (!modifiedArticle.Author.IsNullOrEmpty()))
        {
            article.Author = modifiedArticle.Author;
            article.ModifiedAt = _dateTimeProvider.UtcNow;
        }

        if ((!article.Title.Equals(modifiedArticle.Title)) && (!modifiedArticle.Title.IsNullOrEmpty()))
        {
            article.Title = modifiedArticle.Title;
            article.ModifiedAt = _dateTimeProvider.UtcNow;
        }

        if ((!article.Synopsis.Equals(modifiedArticle.Synopsis)) && (!modifiedArticle.Synopsis.IsNullOrEmpty()))
        {
            article.Synopsis = modifiedArticle.Synopsis;
            article.ModifiedAt = _dateTimeProvider.UtcNow;
        }
        
        if ((!article.Body.Equals(modifiedArticle.Body)) && (!modifiedArticle.Body.IsNullOrEmpty()))
        {
            article.Body = modifiedArticle.Body;
            article.ModifiedAt = _dateTimeProvider.UtcNow;
        }

        _= await _context.SaveChangesAsync();

        return article;

    }

    private IEnumerable<ArticleListItem> GetArticleListItem(List<Article> articles)
    {
        return articles
            .Select(article => new ArticleListItem
            {
                Id = article.Id,
                Author = article.Author,
                Title = article.Title,
                Synopsis = article.Synopsis,
            })
            .ToList();
    }

    private async Task<List<Article>> GetAllArticles()
    {
        return await _context.Articles.ToListAsync();
    }
}
