using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccesse.MSSQL.Entities;

namespace ToDo.DataAccesse.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
/*            builder.Property(x => x.ToDoBoard).HasMaxLength(3).IsRequired();
*/

            builder.HasMany(x => x.ToDoBoard)
                    .WithOne(x => x.User)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
