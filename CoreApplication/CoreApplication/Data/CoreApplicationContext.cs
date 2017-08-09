using Microsoft.EntityFrameworkCore;


namespace CoreApplication.Models
{
    public class CoreApplicationContext : DbContext
    {
        public CoreApplicationContext(DbContextOptions<CoreApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Application { get; set; }

        public DbSet<Question> Question { get; set; }

        public DbSet<Answer> Answer { get; set; }
    }
}
