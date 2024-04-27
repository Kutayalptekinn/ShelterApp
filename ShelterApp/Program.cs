using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShelterApp.Business;
using ShelterApp.Data;
using ShelterApp.DataAccess.EntitiyFrameworkCore;
using ShelterApp.UI.Shared;
using Syncfusion.Blazor;
using System.Globalization;
using Newtonsoft.Json.Serialization;
using ShelterApp.Business.Services.BlogService;

var builder = WebApplication.CreateBuilder(args);
ConfigureBusiness(builder);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddDevExpressBlazor();
//builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
builder.Services.AddControllers();

//builder.Services.AddDbContextFactory<ShelterAppDbContext>(
//        options =>
//            options.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Database=ShelterAppDB;"), ServiceLifetime.Transient);


var app = builder.Build();
app.UseRequestLocalization("tr-TR");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXted3RdQmBeV0BxWkc=");

app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
static void ConfigureBusiness(WebApplicationBuilder builder)
{
    var instance = (BusinessModule)Activator.CreateInstance(typeof(BusinessModule));

    instance.ConfigureServices(builder.Services);
}