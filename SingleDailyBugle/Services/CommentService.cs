using SingleDailyBugle.Models;
using SingleDailyBugle.Models.DTOs;

namespace SingleDailyBugle.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IArticleService _articleService;
        public CommentService(ApplicationDbContext context, IDateTimeProvider dateTimeProvider, IArticleService articleService)
        {
            _context = context;
            _dateTimeProvider = dateTimeProvider;
            _articleService = articleService;
        }

        public async Task CreateCommentAsync(int articleId, CommentInputForm commentInput)
        {
            ArgumentNullException.ThrowIfNull(commentInput);

            if (commentInput.Author is null || commentInput.Body is null)
            {
                throw new EditorialException("You must fill out the necessary brackets with words");
            }

            var article = await _articleService.GetArticleByIdAsync(articleId);

            Comment comment = new Comment
            {
                Author = commentInput.Author,
                Body = commentInput.Body,
                CreatedAt = _dateTimeProvider.UtcNow,
                Article = article,
                ArticleId = article.Id
            };

            _context.Comments.Add(comment);

            //article.Comments.Add(comment);

            _ = await _context.SaveChangesAsync();
        }
    }
}
