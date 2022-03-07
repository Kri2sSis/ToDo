using Microsoft.EntityFrameworkCore;

namespace ToDo.DataAccesse.MSSQL
{
    public class ToDoDbContext : DbContext
    {

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        { }

    }
}