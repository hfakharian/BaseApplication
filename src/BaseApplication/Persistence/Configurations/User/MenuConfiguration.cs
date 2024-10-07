using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.User
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public virtual void Configure(EntityTypeBuilder<Menu> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.Url)
                .HasMaxLength(150)
                .IsUnicode();

            builder.Property(x => x.Icon)
                .HasMaxLength(50)
                .IsUnicode();

            builder.HasOne(x => x.MenuParent)
                 .WithMany()
                 .HasForeignKey(x => x.MenuParentID);


            builder.HasMany(e => e.Roles)
               .WithMany(e => e.Menus)
               .UsingEntity<MenuRole>(
                   r => r.HasOne<Domain.Entities.User.Role>().WithMany().HasForeignKey(e => e.RoleID),
                   l => l.HasOne<Menu>().WithMany().HasForeignKey(e => e.MenuID));

            //builder.HasMany(u => u.MenuRoles)
            //    .WithOne(x => x.Menu)
            //    .HasForeignKey(x => x.MenuID)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
