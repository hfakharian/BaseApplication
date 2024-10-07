using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.Product>
    {
        public virtual void Configure(EntityTypeBuilder<Domain.Entities.Product.Product> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsUnicode();


            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.ProductImages)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
