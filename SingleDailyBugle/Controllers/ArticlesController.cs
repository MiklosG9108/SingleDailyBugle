using Microsoft.AspNetCore.Mvc;
using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;
using SingleDailyBugle.Models.ViewModels;
using SingleDailyBugle.Services;

namespace SingleDailyBugle.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IArticleService _articleService;

    public ArticlesController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    [HttpGet(nameof(GetArticles))]
    public async Task<ActionResult<IEnumerable<ArticleListItem>>> GetArticles()
    {
        var articles = await _articleService.GetAllArticlesAsync();
        return Ok(articles);
    }

    [HttpGet(nameof(GetArticle))]
    public async Task<ActionResult<Article>> GetArticle(int id)
    {
        var article = await _articleService.GetArticleByIdAsync(id);
        return Ok(article);
    }

    [HttpPut(nameof(ModifyArticle))]
    public async Task<IActionResult> ModifyArticle(int id, ArticleInputForm modifiedArticleForm)
    {
        var modifiedarticle = await _articleService.ModifyArticleAsync(id, modifiedArticleForm);
        return Ok(modifiedarticle);
    }

    [HttpPost(nameof(PostArticle))]
    public ActionResult<Article> PostArticle(ArticleInputForm baseArticle)
    {
        var article = _articleService.CreateArticleAsync(baseArticle);
        return Ok();
    }


    [HttpDelete(nameof(DeleteArticle))]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var article = await _articleService.DeleteArticleAsync(id);
        return Ok(article);
    }

    
}
