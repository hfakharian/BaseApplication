using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.Product
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.ProductImage>
    {
        public virtual void Configure(EntityTypeBuilder<Domain.Entities.Product.ProductImage> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID)
                .UseIdentityColumn(seed: 1, increment: 1)
                .IsRequired();


            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
