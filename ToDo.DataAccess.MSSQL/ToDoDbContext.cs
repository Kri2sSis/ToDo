using Microsoft.EntityFrameworkCore;
using ToDo.DataAccess.MSSQL.Configurations;
using ToDo.DataAccess.MSSQL.Entities;

namespace ToDo.DataAccess.MSSQL
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