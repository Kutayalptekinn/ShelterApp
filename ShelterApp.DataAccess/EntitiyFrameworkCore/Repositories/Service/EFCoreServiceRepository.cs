using ShelterApp.Core.Repositories.EntityFrameworkCore;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Service;
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
    public class EFCoreServiceRepository: EfCoreRepository<TBL_Service>, IServiceRepository
    {
        public EFCoreServiceRepository(ShelterAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
