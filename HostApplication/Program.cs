using _0_Framework.Application;
using BlogManagement.Infrastructure.Configuration;
using HostApplication.Features;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetSection("connectionStrings")["BloggerFa"];

builder.Services.AddTransient<IFileUploader, FileUploader>();
BlogManagementBootstrapper.Config(builder.Services,connectionString);


builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
