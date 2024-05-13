using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.Extensions.DependencyInjection;
using ShelterApp.Business;
using System.Reflection;
using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Business.Services.BlogService;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using ShelterApp.Business.Services.ProductService;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Product;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Service;
using ShelterApp.Business.Services.ServiceService;
using ShelterApp.Business.Services.MailService;

namespace ShelterApp.Business
{
    public class BusinessModule
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => options.AddPolicy("AllowLocalhost", builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddMvc();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            SetMapperToObjectMapper();
            services.AddScoped<IProductAppService, ProductAppService>(); 
            services.AddScoped<IBlogAppService, BlogAppService>(); 
            services.AddScoped<IServiceAppService, ServiceAppService>(); 
            services.AddScoped<IBlogRepository, EFCoreBlogRepository>();
            services.AddScoped<IServiceRepository, EFCoreServiceRepository>();
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
