using Microsoft.EntityFrameworkCore;
using Zadania.Models;

var builder = WebApplication.CreateBuilder(args);
// Dodaj DbContext z konfiguracj¹ z appsettings.json
builder.Services.AddDbContext<AaaonninenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.Run();
