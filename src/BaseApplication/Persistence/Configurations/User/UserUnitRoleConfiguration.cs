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
    public class UserUnitRoleConfiguration : IEntityTypeConfiguration<UserUnitRole>
    {
        public virtual void Configure(EntityTypeBuilder<UserUnitRole> builder)
        {

            builder.HasKey(i => new { i.UserID, i.UnitID });
            
            builder.HasIndex(i => new { i.UserID, i.UnitID });


            builder.Property(x => x.UserID)
                .IsRequired();

            builder.Property(x => x.RoleID)
                .IsRequired();

            builder.Property(x => x.IsAccepted)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserUnitRoles)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserUnitRoles)
                .HasForeignKey(x => x.RoleID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Unit)
                .WithMany(x => x.UserUnitRoles)
                .HasForeignKey(x => x.UnitID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
