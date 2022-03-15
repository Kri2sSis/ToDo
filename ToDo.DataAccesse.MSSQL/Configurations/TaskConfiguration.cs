using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.DataAccesse.MSSQL.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Entities.Task> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();


            builder.HasOne(x => x.ToDoBoard)
                    .WithMany(x => x.Tasks)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasPrincipalKey(x => x.Id)
                    .HasForeignKey(x => x.Id);
        }
    }
}
