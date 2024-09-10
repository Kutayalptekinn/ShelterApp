using ShelterApp.Core.BusinessCoreServices;
using ShelterApp.Entities.Entities.Sector.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Business.Services.SectorService
{
    public interface ISectorAppService : ICrudAppService<SelectSectorDto, ListSectorDto, CreateSectorDto, UpdateSectorDto>
    {
        public Task<IList<ListSectorDto>> GetById(int id);
        Task<SelectSectorDto> GetByNameAsync(string name);
        public Task<ListSectorDtoForAPI> GetListAsyncForAPI();


    }
}
