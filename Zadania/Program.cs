using Microsoft.EntityFrameworkCore;
using Zadania.DB;

using Zadania.Repozytorium;

var builder = WebApplication.CreateBuilder(args);
// Dodaj DbContext z konfiguracj¹ z appsettings.json
builder.Services.AddDbContext<DBTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRepository, Repository>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Public}/{action=login}");

    endpoints.MapRazorPages();
});


app.Run();
