using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;
using SingleDailyBugle.Models.ViewModels;

namespace SingleDailyBugle.Services
{
    public interface IArticleService
    {
        Task CreateArticleAsync(ArticleInputForm baseArticle);
        Task<Article> DeleteArticleAsync(int id);
        Task<IEnumerable<ArticleListItem>> GetAllArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        Task<Article> ModifyArticleAsync(int id, ArticleInputForm modifiedArticle);
    }
}