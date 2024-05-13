using ShelterApp.Core.BusinessCoreServices;
using ShelterApp.Entities.Entities.Blog.dtos;
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

    }
}
