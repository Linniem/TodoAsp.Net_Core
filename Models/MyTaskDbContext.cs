using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCore.Models
{
    public class MyTaskDbContext : DbContext
    {
        public MyTaskDbContext(DbContextOptions<MyTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskUnit> TaskUnits { get; set; }
        public DbSet<TaskListGroup> TaskListGroups { get; set; }
    }
}
