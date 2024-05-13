using ShelterApp.Core.Repositories.EntityFrameworkCore;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Sector;
using ShelterApp.Entities.Entities.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Service
{
    public interface IServiceRepository: IEfCoreRepository<TBL_Service>
    {
    }
}
