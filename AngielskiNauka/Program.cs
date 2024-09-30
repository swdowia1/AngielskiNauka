using AngielskiNauka.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AaaswswContext>(x => x.UseSqlServer("workstation id=aaaswsw.mssql.somee.com;packet size=4096;user id=swdowia1_SQLLogin_2;pwd=kr62j5x3px;data source=aaaswsw.mssql.somee.com;persist security info=False;initial catalog=aaaswsw;TrustServerCertificate=True"));


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
//app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Public}/{action=login}");

    endpoints.MapRazorPages();
});

app.Run();
