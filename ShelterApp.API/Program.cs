using ShelterApp.Business;
using ShelterApp.DataAccess.EntitiyFrameworkCore;
using System.Reflection;
using ShelterApp.Core.Utilities.Services.Business.ServiceRegistrations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<ShelterAppDbContext>();

ConfigureBusiness(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
