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
            services.AddScoped<IBlogAppService, BlogAppService>(); 
            services.AddScoped<IBlogRepository, EFCoreBlogRepository>();

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
