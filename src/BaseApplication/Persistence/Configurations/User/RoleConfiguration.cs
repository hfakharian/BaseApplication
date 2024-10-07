using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Security;

namespace Persistence.Configurations.User
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public virtual void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .IsRequired();

            builder.HasIndex(x => x.Title).IsUnique();
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(x => x.Comment)
                .HasMaxLength(1000)
                .IsUnicode();

            builder.HasMany(x => x.UserUnitRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            //builder.HasData(SetSeed());
        }

        public List<Domain.Entities.User.Role> SetSeed()
        {
            List<Domain.Entities.User.Role> seeds = new List<Domain.Entities.User.Role>
            {
                new Role{
                    ID= 1,
                    RoleType = Domain.Entities.User.Enum.RoleType.Private,
                    RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                    Title ="User"
                },
                new Role{
                    ID= 2,
                    RoleType = Domain.Entities.User.Enum.RoleType.Public,
                    RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                    Title ="UnitAdmin"
                },
                new Role{
                    ID= 3,
                    RoleType = Domain.Entities.User.Enum.RoleType.Public,
                    RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                    Title ="UnitLimit"
                },
            };

            return seeds;
        }
    }



}
