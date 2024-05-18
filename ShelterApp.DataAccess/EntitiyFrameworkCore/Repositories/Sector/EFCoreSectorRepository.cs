using ShelterApp.Core.Repositories.EntityFrameworkCore;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Sector;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Sector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Sector
{
    public class EFCoreSectorRepository : EfCoreRepository<TBL_Sector>, ISectorRepository
    {
        public EFCoreSectorRepository(ShelterAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
