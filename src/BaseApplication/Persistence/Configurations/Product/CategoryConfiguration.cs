using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Configurations.Product
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.Category>
    {
        public virtual void Configure(EntityTypeBuilder<Domain.Entities.Product.Category> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsUnicode();


            builder.HasOne(x => x.CategoryParent)
                 .WithMany()
                 .HasForeignKey(x => x.CategoryParentID);

            builder.HasMany(u => u.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
