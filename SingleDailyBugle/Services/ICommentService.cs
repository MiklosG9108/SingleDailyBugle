using SingleDailyBugle.Models.DTOs;

namespace SingleDailyBugle.Services
{
    public interface ICommentService
    {
        Task CreateCommentAsync(int articleId, CommentInputForm commentInput);
    }
}