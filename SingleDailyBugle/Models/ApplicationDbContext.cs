using Microsoft.EntityFrameworkCore;

namespace SingleDailyBugle.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
