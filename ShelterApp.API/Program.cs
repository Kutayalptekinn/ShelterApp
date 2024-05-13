using ShelterApp.Business;
using ShelterApp.DataAccess.EntitiyFrameworkCore;
using System.Reflection;
using ShelterApp.Core.Utilities.Services.Business.ServiceRegistrations;
using System.Data.Entity.Core.Common.CommandTrees;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<ShelterAppDbContext>();


ConfigureBusiness(builder);
builder.Services.AddApplicationInsightsTelemetry();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.InjectJavascript("https://cdnjs.cloudflare.com/ajax/libs/swagger-ui/4.1.3/swagger-ui-bundle.js", "text/javascript");
    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ShelterApp.API");
    c.RoutePrefix = string.Empty;
});
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("//swagger/v1/swagger.json", "Employee API V1");
//    });
//}

app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureBusiness(WebApplicationBuilder builder)
{
    builder.Services.RegisterDependencies(Assembly.Load("ShelterApp.Business"));

    var instance = (BusinessModule)Activator.CreateInstance(typeof(BusinessModule));

    instance.ConfigureServices(builder.Services);
}
