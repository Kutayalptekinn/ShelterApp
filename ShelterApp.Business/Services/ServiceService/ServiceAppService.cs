using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.Entities.Entities.Service;
using ShelterApp.Entities.Entities.Service.dtos;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Service;
using ShelterApp.Entities.Entities.Sector;


namespace ShelterApp.Business.Services.ServiceService
{
    public class ServiceAppService:IServiceAppService
    {
        private readonly IServiceRepository _repository;

        public ServiceAppService(IServiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<SelectServiceDto> CreateAsync(CreateServiceDto input)
        {
            var entity = ObjectMapper.Map<CreateServiceDto, TBL_Service>(input);

            var addedEntity = await _repository.InsertAsync(entity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Service, SelectServiceDto>(addedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChanges();
        }

        public async Task<SelectServiceDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<TBL_Service, SelectServiceDto>(entity);

            return mappedEntity;
        }

        public async Task<IList<ListServiceDto>> GetListAsync()
        {
            var list = await _repository.GetListAsync();

            var mappedEntity = ObjectMapper.Map<List<TBL_Service>, List<ListServiceDto>>(list.ToList());

            return mappedEntity;
        }

        public async Task<SelectServiceDto> UpdateAsync(UpdateServiceDto input)
        {
            var entity = await _repository.GetAsync(x => x.ID == input.ID);


            var mappedEntity = ObjectMapper.Map<UpdateServiceDto, TBL_Service>(input);

            await _repository.UpdateAsync(mappedEntity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Service, SelectServiceDto>(mappedEntity);
        }

        public async Task<IList<ListServiceDto>> GetById(int id)
        {
            var list = await _repository.GetListAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<List<TBL_Service>, List<ListServiceDto>>(list.ToList());

            return mappedEntity;

        }
    }
}
