using Microsoft.EntityFrameworkCore;
using ToDo.DataAccess.MSSQL.Entities;

namespace ToDo.DataAccess.MSSQL.Configurations
{
    public class ToDoBoardConfiguration : IEntityTypeConfiguration<ToDoBoard>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ToDoBoard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Status).HasConversion<int>().IsRequired();

            builder.HasOne(x => x.User)
                    .WithMany(x => x.ToDoBoard)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Tasks)
                    .WithOne(x => x.ToDoBoard)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired(false);
        }
    }
}
