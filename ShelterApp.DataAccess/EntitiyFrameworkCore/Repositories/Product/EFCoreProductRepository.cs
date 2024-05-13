using ShelterApp.Core.Repositories.EntityFrameworkCore;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Blog;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.DataAccess.EntitiyFrameworkCore.Repositories.Product
{
    public class EFCoreProductRepository: EfCoreRepository<TBL_Product>, IProductRepository
    {
        public EFCoreProductRepository(ShelterAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
