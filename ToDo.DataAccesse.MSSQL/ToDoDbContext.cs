using Microsoft.EntityFrameworkCore;
using ToDo.DataAccesse.MSSQL.Configurations;
using ToDo.DataAccesse.MSSQL.Entities;

namespace ToDo.DataAccesse.MSSQL
{
    public class ToDoDbContext : DbContext
    {

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoBoard> Boards { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoBoardConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}