using BlogManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetSection("connectionStrings")["BloggerFa"];

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
