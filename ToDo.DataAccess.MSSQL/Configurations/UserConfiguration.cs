using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DataAccess.MSSQL.Entities;

namespace ToDo.DataAccess.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Entities.User>
    {
        public void Configure(EntityTypeBuilder<Entities.User> builder)
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
