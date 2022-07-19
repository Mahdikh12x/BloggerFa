using BlogManagement.Domain.TagAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Configurations
{
    internal class TagMapping:IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(125).IsRequired();

            //builder.HasMany(p => p.Posts).WithMany(t => t.Tags);
        }
    }
}
