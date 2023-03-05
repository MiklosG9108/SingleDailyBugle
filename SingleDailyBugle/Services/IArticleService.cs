using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;
using SingleDailyBugle.Models.ViewModels;

namespace SingleDailyBugle.Services
{
    public interface IArticleService
    {
        Task<Article> CreateArticleAsync(ArticleInputForm baseArticle);
        Task<Article> DeleteArticleAsync(int id);
        Task<IEnumerable<ArticleListItem>> GetAllArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        Task<ArticleFullView> GetArticleWithCommentsAsync(Article article);
        Task<Article> ModifyArticleAsync(int id, ArticleInputForm modifiedArticle);
    }
}