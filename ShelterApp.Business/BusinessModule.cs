using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.Extensions.DependencyInjection;
using ShelterApp.Business;
using System.Reflection;
using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Business.Services.BlogService;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;
using Microsoft.AspNetCore.Http;

namespace ShelterApp.Business
{
    public class BusinessModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
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
