using ShelterApp.Core.BusinessCoreServices;
using ShelterApp.Entities.Entities.Privilege.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Business.Services.PrivilegeService
{
    public interface IPrivilegeAppService : ICrudAppService<SelectPrivilegeDto, ListPrivilegeDto, CreatePrivilegeDto, UpdatePrivilegeDto>
    {
        public Task<IList<ListPrivilegeDto>> GetById(int id);

    }
}
