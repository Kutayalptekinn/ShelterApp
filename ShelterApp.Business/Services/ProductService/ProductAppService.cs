using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Entities.Entities.Product;
using ShelterApp.Entities.Entities.Product.dtos;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Product;
using ShelterApp.Business.Services.ProductService;


namespace ShelterApp.Business.Services.ProductService
{
    public class ProductAppService:IProductAppService
    {
        private readonly IProductRepository _repository;

        public ProductAppService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<SelectProductDto> CreateAsync(CreateProductDto input)
        {
            var entity = ObjectMapper.Map<CreateProductDto, TBL_Product>(input);

            var addedEntity = await _repository.InsertAsync(entity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Product, SelectProductDto>(addedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChanges();
        }

        public async Task<SelectProductDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<TBL_Product, SelectProductDto>(entity);

            return mappedEntity;
        }

        public async Task<IList<ListProductDto>> GetListAsync()
        {
            var list = await _repository.GetListAsync();

            var mappedEntity = ObjectMapper.Map<List<TBL_Product>, List<ListProductDto>>(list.ToList());

            return mappedEntity;
        }

        public async Task<SelectProductDto> UpdateAsync(UpdateProductDto input)
        {
            var entity = await _repository.GetAsync(x => x.ID == input.ID);


            var mappedEntity = ObjectMapper.Map<UpdateProductDto, TBL_Product>(input);

            await _repository.UpdateAsync(mappedEntity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Product, SelectProductDto>(mappedEntity);
        }

        public async Task<IList<ListProductDto>> GetById(int id)
        {
            var list = await _repository.GetListAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<List<TBL_Product>, List<ListProductDto>>(list.ToList());

            return mappedEntity;

        }
    }
}
