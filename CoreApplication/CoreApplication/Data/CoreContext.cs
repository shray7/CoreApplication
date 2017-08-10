using CoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.Data
{
  public class CoreContext : DbContext
  {
    public CoreContext(DbContextOptions<CoreContext> options): base(options){}

    public DbSet<Answers> Answer { get; set; }
    public DbSet<Questions> Question { get; set; }
    public DbSet<Application> Application { get; set; }
  }

}
