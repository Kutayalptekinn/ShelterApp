using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Entities.Entities.Product;
using ShelterApp.Entities.Entities.Product.dtos;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Product;
using ShelterApp.Business.Services.ProductService;
using ShelterApp.Entities.Entities.Product.dtos;
using ShelterApp.Entities.Entities.Sector.dtos;
using ShelterApp.Entities.Entities.Sector;
using ShelterApp.Entities.Entities.Blog.dtos;


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
        public async Task<ListProductDtoForAPI> GetListAsyncForAPI()
        {

            var list = await _repository.GetListAsync();
            ListProductDtoForAPI listProductDtos = new ListProductDtoForAPI();
            listProductDtos.TR = new List<ListProductDto>();
            listProductDtos.GB = new List<ListProductDto>();
            listProductDtos.RU = new List<ListProductDto>();

            Dictionary<string, int> fotoIdMap = new Dictionary<string, int>();
            foreach (var item in list)
            {

                ListProductDto listProductDto = new ListProductDto();

                if (fotoIdMap.ContainsKey(item.FrontPhoto))
                {
                    // Eğer Foto daha önce eklenmişse, aynı ID'yi kullanıyoruz
                    listProductDto.ID = fotoIdMap[item.FrontPhoto];
                }
                else
                {
                    // Eğer Foto daha önce eklenmemişse, yeni ID'yi kullanıyoruz ve sözlüğe ekliyoruz
                    listProductDto.ID = item.ID;
                    fotoIdMap[item.FrontPhoto] = item.ID;
                }
                listProductDto.Detay = item.Detay;
                listProductDto.UstBaslik = item.UstBaslik;
                listProductDto.Icerik = item.Icerik;
                listProductDto.FrontPhoto = item.FrontPhoto;
                listProductDto.Photo1 = item.Photo1;
                listProductDto.Photo2 = item.Photo2;
                listProductDto.Photo3 = item.Photo3;
                listProductDto.Isim = item.Isim;
                listProductDto.Baslik = item.Baslik;
                listProductDto.Language = item.Language;

                if (item.Language == "TR")
                {
                    listProductDtos.TR.Add(listProductDto);
                }

                else if (item.Language == "GB")
                {
                    listProductDtos.GB.Add(listProductDto);
                }

                else if (item.Language == "RU")
                {
                    listProductDtos.RU.Add(listProductDto);
                }
            }
            return listProductDtos;
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
        public async Task<SelectProductDto> GetByIsimAsync(string isim)
        {

            var product = await _repository.GetAsync(t => t.Isim == isim);

            var trProduct = _repository.GetListAsync().Result.FirstOrDefault(x => x.FrontPhoto == product.FrontPhoto);
            if (trProduct != null)
            {
                product.ID = trProduct.ID;

            }

            var mappedEntity = ObjectMapper.Map<TBL_Product, SelectProductDto>(product);

            return mappedEntity;

        }
    }
}
