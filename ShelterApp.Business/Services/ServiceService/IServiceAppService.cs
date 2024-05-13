using ShelterApp.Core.BusinessCoreServices;
using ShelterApp.Entities.Entities.Service.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Business.Services.ServiceService
{
    public interface IServiceAppService : ICrudAppService<SelectServiceDto, ListServiceDto, CreateServiceDto, UpdateServiceDto>
    {
        public Task<IList<ListServiceDto>> GetById(int id);

    }
}
