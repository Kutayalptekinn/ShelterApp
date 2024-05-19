using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Sector;
using ShelterApp.Entities.Entities.Privilege.dtos;
using ShelterApp.Entities.Entities.Privilege;
using ShelterApp.Entities.Entities.Sector;
using ShelterApp.Entities.Entities.Sector.dtos;
using ShelterApp.Core.Entities;



namespace ShelterApp.Business.Services.SectorService
{
    public class SectorAppService:ISectorAppService
    {
        private readonly ISectorRepository _repository;

        public SectorAppService(ISectorRepository repository)
        {
            _repository = repository;
        }
        public async Task<SelectSectorDto> CreateAsync(CreateSectorDto input)
        {
            var entity = ObjectMapper.Map<CreateSectorDto, TBL_Sector>(input);

            var addedEntity = await _repository.InsertAsync(entity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Sector, SelectSectorDto>(addedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChanges();
        }

        public async Task<SelectSectorDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<TBL_Sector, SelectSectorDto>(entity);

            return mappedEntity;
        }

        public async Task<IList<ListSectorDto>> GetListAsync()
        {
            var list = await _repository.GetListAsync();

            var mappedEntity = ObjectMapper.Map<List<TBL_Sector>, List<ListSectorDto>>(list.ToList());

            return mappedEntity;
        }

        public async Task<SelectSectorDto> UpdateAsync(UpdateSectorDto input)
        {
            var entity = await _repository.GetAsync(x => x.ID == input.ID);


            var mappedEntity = ObjectMapper.Map<UpdateSectorDto, TBL_Sector>(input);

            await _repository.UpdateAsync(mappedEntity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Sector, SelectSectorDto>(mappedEntity);
        }

        public async Task<IList<ListSectorDto>> GetById(int id)
        {
            var list = await _repository.GetListAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<List<TBL_Sector>, List<ListSectorDto>>(list.ToList());

            return mappedEntity;

        }
        public async Task<SelectSectorDto> GetByNameAsync(string name)
        {
            var sector = await _repository.GetAsync(t => t.SectorName == name);

            var mappedEntity = ObjectMapper.Map<TBL_Sector, SelectSectorDto>(sector);

            return mappedEntity;

        }
    }
}
