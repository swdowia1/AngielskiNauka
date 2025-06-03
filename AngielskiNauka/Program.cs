using AngielskiNauka;
using AngielskiNauka.ModelApi;
using AngielskiNauka.Models;
using AngielskiNauka.Resources;
using AngielskiNauka.Serwisy;
using AngielskiNauka.Unit;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog.Web;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Set up NLog for Dependency Injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();  // Enable NLog


// Add services to the container.ddd
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AaaswswContext>(options =>
    options.UseSqlServer(classFun.Poloczenie()));
builder.Services.AddSingleton<LocService>();
builder.Services.AddSingleton<ConfigGlobal>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<AngService>();  //Localizations languages
//builder.Services.AddScoped<TaskService>();  //Localizations languages
builder.Services.AddSingleton<RabbitMQSend>();
//builder.Services.AddHostedService<RabbitMqBackgroundConsumer>();
//IDataCache

builder.Services.AddSignalR();




builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCultures = new List<CultureInfo>
            {
                            new CultureInfo("pl-PL")
            };

        options.DefaultRequestCulture = new RequestCulture(culture: "pl-PL", uiCulture: "pl-PL");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;

     
        options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
    });

builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
        {
            var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
            return factory.Create("SharedResource", assemblyName.Name);
        };
    });


var app = builder.Build();
//app.MapHub<TaskHub>("/taskHub");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

var cultures = new[] { new CultureInfo("en"), new CultureInfo("de") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = cultures,
    SupportedUICultures = cultures
});

app.UseRouting();

var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(locOptions);
app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/chathub"); // mapuj hub
//app.MapControllers();
app.UseEndpoints(endpoints =>
{
  
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Public}/{action=login}");

    endpoints.MapRazorPages();
});

app.Run();
