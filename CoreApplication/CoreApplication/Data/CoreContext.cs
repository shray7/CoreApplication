using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication.Models
{
  public class CoreContext : DbContext
  {
    public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
    {
    }

    public DbSet<Answers> Answer { get; set; }

    public DbSet<Questions> Question { get; set; }
    public DbSet<Application> Application { get; set; }
  }
}
