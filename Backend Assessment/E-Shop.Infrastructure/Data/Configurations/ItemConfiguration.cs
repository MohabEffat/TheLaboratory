namespace E_Shop.Infrastructure.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(i => i.QuantityInStock)
                .IsRequired();

            builder.Property(i => i.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
