using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Blog.dtos;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;
using ShelterApp.Entities.Entities.Blog.dtos;
using ShelterApp.Entities.Entities.Sector.dtos;
using ShelterApp.Entities.Entities.Sector;
using ShelterApp.Entities.Entities.Product.dtos;

namespace ShelterApp.Business.Services.BlogService
{
    public class BlogAppService:IBlogAppService
    {
        private readonly IBlogRepository _repository;

        public BlogAppService(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<SelectBlogDto> CreateAsync(CreateBlogDto input)
        {
            var entity = ObjectMapper.Map<CreateBlogDto, TBL_Blog>(input);

            var addedEntity = await _repository.InsertAsync(entity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Blog, SelectBlogDto>(addedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChanges();
        }
        public async Task<ListBlogDtoForAPI> GetListAsyncForAPI()
        {
            var list = await _repository.GetListAsync();
            ListBlogDtoForAPI listBlogDtos = new ListBlogDtoForAPI();
            listBlogDtos.TR = new List<ListBlogDto>();
            listBlogDtos.GB = new List<ListBlogDto>();
            listBlogDtos.RU = new List<ListBlogDto>();

            // Önceden kaydedilmiş Foto'ları ve ID'leri takip etmek için bir sözlük oluşturuyoruz
            Dictionary<string, int> fotoIdMap = new Dictionary<string, int>();

            foreach (var item in list)
            {
                ListBlogDto listBlogDto = new ListBlogDto();

                if (fotoIdMap.ContainsKey(item.Foto))
                {
                    // Eğer Foto daha önce eklenmişse, aynı ID'yi kullanıyoruz
                    listBlogDto.ID = fotoIdMap[item.Foto];
                }
                else
                {
                    // Eğer Foto daha önce eklenmemişse, yeni ID'yi kullanıyoruz ve sözlüğe ekliyoruz
                    listBlogDto.ID = item.ID;
                    fotoIdMap[item.Foto] = item.ID;
                }

                listBlogDto.Konu = item.Konu;
                listBlogDto.Tarih = item.Tarih;
                listBlogDto.Icerik = item.Icerik;
                listBlogDto.Foto = item.Foto;
                listBlogDto.Baslik = item.Baslik;
                listBlogDto.Language = item.Language;

                if (item.Language == "TR")
                {
                    listBlogDtos.TR.Add(listBlogDto);
                }
                else if (item.Language == "GB")
                {
                    listBlogDtos.GB.Add(listBlogDto);
                }
                else if (item.Language == "RU")
                {
                    listBlogDtos.RU.Add(listBlogDto);
                }
            }
            return listBlogDtos;
        }

        public async Task<SelectBlogDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<TBL_Blog, SelectBlogDto>(entity);

            return mappedEntity;
        }

        public async Task<IList<ListBlogDto>> GetListAsync()
        {
            var list = await _repository.GetListAsync();

            var mappedEntity = ObjectMapper.Map<List<TBL_Blog>, List<ListBlogDto>>(list.ToList());

            return mappedEntity;
        }

        public async Task<SelectBlogDto> UpdateAsync(UpdateBlogDto input)
        {
            var entity = await _repository.GetAsync(x => x.ID == input.ID);


            var mappedEntity = ObjectMapper.Map<UpdateBlogDto, TBL_Blog>(input);

            await _repository.UpdateAsync(mappedEntity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Blog, SelectBlogDto>(mappedEntity);
        }

        public async Task<IList<ListBlogDto>> GetById(int id)
        {
            var list = await _repository.GetListAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<List<TBL_Blog>, List<ListBlogDto>>(list.ToList());

            return mappedEntity;

        }

        public async Task<SelectBlogDto> GetByBaslikAsync(string baslik)
        {
            var blog = await _repository.GetAsync(t => t.Baslik == baslik);

            var trBlog = _repository.GetListAsync().Result.FirstOrDefault(x => x.Foto == blog.Foto);
            if (trBlog != null)
            {
                blog.ID = trBlog.ID;

            }

            var mappedEntity = ObjectMapper.Map<TBL_Blog, SelectBlogDto>(blog);

            return mappedEntity;
        }

    }
}
