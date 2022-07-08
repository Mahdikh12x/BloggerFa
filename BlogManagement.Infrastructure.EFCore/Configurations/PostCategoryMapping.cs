using BlogManagement.Domain.PostCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Configurations
{
    internal class PostCategoryMapping:IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Name).HasMaxLength(500).IsRequired();
            builder.Property(pc => pc.Picture).HasMaxLength(1000).IsRequired(false);
            builder.Property(pc => pc.Description).HasMaxLength(2500).IsRequired(false);
            builder.Property(pc => pc.PictureAlt).HasMaxLength(250).IsRequired(false);
            builder.Property(pc => pc.PictureTitle).HasMaxLength(500).IsRequired(false);
            builder.Property(pc => pc.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(pc => pc.Slug).HasMaxLength(500).IsRequired();
            builder.Property(pc => pc.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(pc => pc.CanonicalAddress).HasMaxLength(1000).IsRequired();

            builder.HasMany(p => p.Posts)
                .WithOne(pc => pc.PostCategory)
                .HasForeignKey(fk => fk.CategoryId);
        }

    }
}
