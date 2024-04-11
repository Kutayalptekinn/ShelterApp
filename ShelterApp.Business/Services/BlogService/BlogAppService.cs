using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Blog.dtos;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;

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

        public async Task<SelectBlogDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<TBL_Blog, SelectBlogDto>(entity);

            return mappedEntity;
        }

        public async Task<IList<ListBlogDto>> GetListAsync()
        {
            var list = await _repository.GetListAsync(null);

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
    }
}
