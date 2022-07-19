using BlogManagement.Domain.PostAgg;
using BlogManagement.Domain.PostCategoryAgg;
using BlogManagement.Domain.TagAgg;
using BlogManagement.Infrastructure.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore
{
    public class BlogContext:DbContext
    {

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PostMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tag>? Tags { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<PostCategory>? PostCategories { get; set; }
    }
}