using ShelterApp.Core.BusinessCoreServices;
using ShelterApp.Entities.Entities.Blog.dtos;
using ShelterApp.Entities.Entities.Privilege.dtos;
using ShelterApp.Entities.Entities.Sector.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Business.Services.BlogService
{
    public interface IBlogAppService : ICrudAppService<SelectBlogDto, ListBlogDto, CreateBlogDto, UpdateBlogDto>
    {
        public Task<IList<ListBlogDto>> GetById(int id);
        public Task<ListBlogDtoForAPI> GetListAsyncForAPI();
        Task<SelectBlogDto> GetByBaslikAsync(string name);


    }
}
