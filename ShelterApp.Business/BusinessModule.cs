using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.Extensions.DependencyInjection;
using ShelterApp.Business;
using System.Reflection;
using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Business.Services.BlogService;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using ShelterApp.Business.Services.ProductService;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Product;
using ShelterApp.Business.Services.MailService;
using ShelterApp.Business.Services.SectorService;
using ShelterApp.Business.Services.PrivilegeService;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Sector;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Privilege;

namespace ShelterApp.Business
{
    public class BusinessModule
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => options.AddPolicy("AllowLocalhost", builder =>
            {
                builder.WithOrigins("http://localhost:3000", "https://duos-flame.vercel.app")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            SetMapperToObjectMapper();
            services.AddScoped<IProductAppService, ProductAppService>(); 
            services.AddScoped<IBlogAppService, BlogAppService>(); 
            services.AddScoped<ISectorAppService, SectorAppService>(); 
            services.AddScoped<IPrivilegeAppService, PrivilegeAppService>(); 
            services.AddScoped<IBlogRepository, EFCoreBlogRepository>();
            services.AddScoped<ISectorRepository, EFCoreSectorRepository>();
            services.AddScoped<IPrivilegeRepository, EFCorePrivilegeRepository>();
            services.AddScoped<IProductRepository, EFCoreProductRepository>();
            services.AddTransient<IEmailSender, EmailSender>();
        }
        static void SetMapperToObjectMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            ObjectMapper.Mapper = new Mapper(config);

        }

    }
}
