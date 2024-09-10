using ShelterApp.Core.BusinessCoreServices;
using ShelterApp.Entities.Entities.Blog.dtos;
using ShelterApp.Entities.Entities.Product.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Business.Services.ProductService
{
    public interface IProductAppService : ICrudAppService<SelectProductDto, ListProductDto, CreateProductDto, UpdateProductDto>
    {
        public Task<IList<ListProductDto>> GetById(int id);
        public Task<ListProductDtoForAPI> GetListAsyncForAPI();
        Task<SelectProductDto> GetByIsimAsync(string isim);

    }
}
