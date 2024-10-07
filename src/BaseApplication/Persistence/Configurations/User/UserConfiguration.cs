using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.Configurations.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User.User>
    {
        public virtual void Configure(EntityTypeBuilder<Domain.Entities.User.User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .IsRequired();

            builder.HasIndex(i => i.Mobile)
                .IsUnique();

            builder.HasIndex(i => i.Email)
                .IsUnique();

            builder.HasIndex(i => i.Username)
                .IsUnique();

            builder.HasIndex(i => i.Password);


            builder.Property(x => x.NationalCode)
                .IsRequired(false)
                .HasMaxLength(10);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.Mobile)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.DateChangePassword)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.DateForgotPassword)
                .IsRequired()
                .HasDefaultValueSql("getdate()");



            builder.HasOne(u => u.UserDetail)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserDetail>(ud => ud.UserID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(u => u.UserUnitRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);


            //builder.HasData(SetSeed());
        }


        /*public List<Domain.Entities.User.User> SetSeed()
        {
            List<Domain.Entities.User.User> seeds = new List<Domain.Entities.User.User>
            {
            };

            return seeds;
        }*/

    }
}
