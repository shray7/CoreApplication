using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreApplication.Models;

namespace CoreApplication.Models
{
    public class CoreApplicationContext : DbContext
    {
        public CoreApplicationContext (DbContextOptions<CoreApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<CoreApplication.Models.Application> Application { get; set; }

        public DbSet<CoreApplication.Models.Question> Question { get; set; }

        public DbSet<CoreApplication.Models.Answer> Answer { get; set; }
    }
}
