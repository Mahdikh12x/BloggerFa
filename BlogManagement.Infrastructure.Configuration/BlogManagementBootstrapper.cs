using BlogManagement.Application;
using BlogManagement.Application.Contracts.Post;
using BlogManagement.Application.Contracts.PostCategory;
using BlogManagement.Domain.PostAgg;
using BlogManagement.Domain.PostCategoryAgg;
using BlogManagement.Infrastructure.EFCore;
using BlogManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Infrastructure.Configuration
{
    public static class BlogManagementBootstrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IPostCategoryRepository, PostCategoryRepository>();
            services.AddTransient<IPostCategoryApplication, PostCategoryApplication>();

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostApplication, PostApplication>();

            services.AddDbContext<BlogContext>(x=>x.UseSqlServer(connectionString));
        }
    }
}