using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Sector;
using ShelterApp.Entities.Entities.Sector.dtos;
using ShelterApp.Entities.Entities.Sector;
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
        public async Task<ListSectorDtoForAPI> GetListAsyncForAPI()
        {
            var list = await _repository.GetListAsync();
            ListSectorDtoForAPI listSectorDtos = new ListSectorDtoForAPI();
            listSectorDtos.TR = new List<ListSectorDto>();
            listSectorDtos.GB = new List<ListSectorDto>();
            listSectorDtos.RU = new List<ListSectorDto>();

            // Önceden kaydedilmiş FrontPhoto'ları ve ID'leri takip etmek için bir sözlük oluşturuyoruz
            Dictionary<string, int> frontPhotoIdMap = new Dictionary<string, int>();

            foreach (var item in list)
            {
                ListSectorDto listSectorDto = new ListSectorDto();

                if (frontPhotoIdMap.ContainsKey(item.FrontPhoto))
                {
                    // Eğer FrontPhoto daha önce eklenmişse, aynı ID'yi kullanıyoruz
                    listSectorDto.ID = frontPhotoIdMap[item.FrontPhoto];
                }
                else
                {
                    // Eğer FrontPhoto daha önce eklenmemişse, yeni ID'yi kullanıyoruz ve sözlüğe ekliyoruz
                    listSectorDto.ID = item.ID;
                    frontPhotoIdMap[item.FrontPhoto] = item.ID;
                }

                listSectorDto.TextInPicture = item.TextInPicture;
                listSectorDto.HeaderText = item.HeaderText;
                listSectorDto.ContentText = item.ContentText;
                listSectorDto.FrontPhoto = item.FrontPhoto;
                listSectorDto.Photo1 = item.Photo1;
                listSectorDto.Photo2 = item.Photo2;
                listSectorDto.Photo3 = item.Photo3;
                listSectorDto.SectorName = item.SectorName;
                listSectorDto.Language = item.Language;

                if (item.Language == "TR")
                {
                    listSectorDtos.TR.Add(listSectorDto);
                }
                else if (item.Language == "GB")
                {
                    listSectorDtos.GB.Add(listSectorDto);
                }
                else if (item.Language == "RU")
                {
                    listSectorDtos.RU.Add(listSectorDto);
                }
            }
            return listSectorDtos;
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

            var trSector= _repository.GetListAsync().Result.FirstOrDefault(x=>x.FrontPhoto == sector.FrontPhoto);
            if (trSector != null)
            {
                sector.ID = trSector.ID;

            }

            var mappedEntity = ObjectMapper.Map<TBL_Sector, SelectSectorDto>(sector);

            return mappedEntity;

        }
    }
}
