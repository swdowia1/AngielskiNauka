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



builder.Services.AddScoped<IFunVMS, FunVMS>();
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

        // You can change which providers are configured to determine the culture for requests, or even add a custom
        // provider with your own logic. The providers will be asked in order to provide a culture for each request,
        // and the first to provide a non-null result that is in the configured supported cultures list will be used.
        // By default, the following built-in providers are configured:
        // - QueryStringRequestCultureProvider, sets culture via "culture" and "ui-culture" query string values, useful for testing
        // - CookieRequestCultureProvider, sets culture via "ASPNET_CULTURE" cookie
        // - AcceptLanguageHeaderRequestCultureProvider, sets culture via the "Accept-Language" request header
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
//app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Public}/{action=login}");

    endpoints.MapRazorPages();
});

app.Run();
