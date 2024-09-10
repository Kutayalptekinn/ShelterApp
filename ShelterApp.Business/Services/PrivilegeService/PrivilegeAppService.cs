using ShelterApp.Core.Utilities.MapperUtilities.Extensions;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Privilege;
using ShelterApp.Entities.Entities.Privilege;
using ShelterApp.Entities.Entities.Privilege.dtos;
using Google.Cloud.Translation.V2;
using Google.Apis.Services;
using Google.Apis.Translate.v2;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis;
using ShelterApp.Core.Utilities.Results;


namespace ShelterApp.Business.Services.PrivilegeService
{
    public class PrivilegeAppService:IPrivilegeAppService
    {

        private readonly IPrivilegeRepository _repository;
        public PrivilegeAppService(IPrivilegeRepository repository)
        {
            _repository = repository;
        }

        public async Task<SelectPrivilegeDto> CreateAsync(CreatePrivilegeDto input)
        {
            var entity = ObjectMapper.Map<CreatePrivilegeDto, TBL_Privilege>(input);

            var addedEntity = await _repository.InsertAsync(entity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Privilege, SelectPrivilegeDto>(addedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChanges();
        }

        public async Task<SelectPrivilegeDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<TBL_Privilege, SelectPrivilegeDto>(entity);

            return mappedEntity;
        }

        public async Task<IList<ListPrivilegeDto>> GetListAsync()
        {
            var list = await _repository.GetListAsync();

            var mappedEntity = ObjectMapper.Map<List<TBL_Privilege>, List<ListPrivilegeDto>>(list.ToList());

            return mappedEntity;
        }
        public async Task<ListPrivilegeDtoForAPI> GetListAsyncForAPI()
        {

            var list = await _repository.GetListAsync();
            ListPrivilegeDtoForAPI listPrivilegeDtos = new ListPrivilegeDtoForAPI();
            listPrivilegeDtos.TR = new List<ListPrivilegeDto>();
            listPrivilegeDtos.GB = new List<ListPrivilegeDto>();
            listPrivilegeDtos.RU = new List<ListPrivilegeDto>();
            foreach (var item in list)
            {
                ListPrivilegeDto listPrivilegeDto = new ListPrivilegeDto();

                listPrivilegeDto.ID = item.ID;

                if (item.Language=="TR")
                {
                    listPrivilegeDto.TextInPicture = item.TextInPicture;
                    listPrivilegeDto.Photo = item.Photo;
                    listPrivilegeDto.PrivilegeName = item.PrivilegeName;
                    listPrivilegeDto.Language = "TR";
                    listPrivilegeDtos.TR.Add(listPrivilegeDto);
                }

                else if (item.Language == "GB")
                {
                    listPrivilegeDto.TextInPicture = item.TextInPicture;
                    listPrivilegeDto.Photo = item.Photo;
                    listPrivilegeDto.PrivilegeName = item.PrivilegeName;
                    listPrivilegeDto.Language = "GB";

                    listPrivilegeDtos.GB.Add(listPrivilegeDto);
                }

                else if (item.Language == "RU")
                {
                    listPrivilegeDto.TextInPicture = item.TextInPicture;
                    listPrivilegeDto.Photo = item.Photo;
                    listPrivilegeDto.PrivilegeName = item.PrivilegeName;
                    listPrivilegeDto.Language = "RU";

                    listPrivilegeDtos.RU.Add(listPrivilegeDto);

                }
            }
            return listPrivilegeDtos;
        }

        public async Task<SelectPrivilegeDto> UpdateAsync(UpdatePrivilegeDto input)
        {
            var entity = await _repository.GetAsync(x => x.ID == input.ID);


            var mappedEntity = ObjectMapper.Map<UpdatePrivilegeDto, TBL_Privilege>(input);

            await _repository.UpdateAsync(mappedEntity);

            await _repository.SaveChanges();

            return ObjectMapper.Map<TBL_Privilege, SelectPrivilegeDto>(mappedEntity);
        }

        public async Task<IList<ListPrivilegeDto>> GetById(int id)
        {
            var list = await _repository.GetListAsync(t => t.ID == id);

            var mappedEntity = ObjectMapper.Map<List<TBL_Privilege>, List<ListPrivilegeDto>>(list.ToList());

            return mappedEntity;

        }
    }
}
