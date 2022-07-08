using BlogManagement.Domain.PostAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Configurations
{
    public class PostMapping:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Title).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Picture).HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.PictureAlt).HasMaxLength(250).IsRequired(false);
            builder.Property(p => p.PictureTitle).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.Link).HasMaxLength(1000).IsRequired(false);
            builder.Property(p => p.ShortDescription).HasMaxLength(1500).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CanonicalAddress).HasMaxLength(1000).IsRequired();

            builder.HasOne(pc => pc.PostCategory)
                .WithMany(p => p.Posts)
                .HasForeignKey(fk => fk.CategoryId);

        }
    }
}
