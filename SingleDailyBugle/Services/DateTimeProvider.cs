using static SingleDailyBugle.Services.DateTimeProvider;

namespace SingleDailyBugle.Services;


public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}
