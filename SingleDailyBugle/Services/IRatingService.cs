using SingleDailyBugle.Models.DTOs;

namespace SingleDailyBugle.Services
{
    public interface IRatingService
    {
        Task CreateRatingAsync(int articleId, RatingInputForm rating);
    }
}