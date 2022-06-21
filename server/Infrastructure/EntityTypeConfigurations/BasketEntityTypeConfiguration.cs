using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasMany(t => t.Items)
                .WithOne(t => t.Basket)
                .HasForeignKey(t => t.BasketId);
        }
    }
}