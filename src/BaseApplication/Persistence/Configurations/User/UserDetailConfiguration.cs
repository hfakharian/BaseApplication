using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.User
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public virtual void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(i => i.UserID);

            builder.Property(x => x.Address)
                .HasMaxLength(500)
                .IsUnicode();

            builder.Property(x => x.Phone)
                .HasMaxLength(15);

            builder.Property(x => x.Image)
                .IsUnicode();

            builder.HasOne(x => x.User)
                 .WithOne(x => x.UserDetail)
                 .HasForeignKey<UserDetail>(x => x.UserID);
        }
    }
}
