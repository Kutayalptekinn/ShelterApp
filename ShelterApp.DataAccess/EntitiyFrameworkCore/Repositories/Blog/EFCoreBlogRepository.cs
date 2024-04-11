using ShelterApp.Core.Repositories.EntityFrameworkCore;
using ShelterApp.Entities.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog
{
    public class EFCoreBlogRepository : EfCoreRepository<TBL_Blog>, IBlogRepository
    {
        public EFCoreBlogRepository(ShelterAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
