using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityTypeConfigurations
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.Basket)
                .WithMany(t => t.Items)
                .HasForeignKey(t => t.BasketId);
        }
    }
}