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
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public virtual void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.Comment)
                .HasMaxLength(1000)
                .IsUnicode();

            builder.Property(x => x.Website)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.HasOne(x => x.UnitParent)
                 .WithMany()
                 .HasForeignKey(x => x.UnitParentID);

            builder.HasOne(uc => uc.UnitDetail)
                .WithOne(ud => ud.Unit)
                .HasForeignKey<UnitDetail>(ud => ud.UnitID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);


            builder
               .HasMany(uc => uc.UserUnitRoles)
               .WithOne()
               .IsRequired(false);


        }
    }
}
