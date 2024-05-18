using AutoMapper;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Blog.dtos;
using ShelterApp.Entities.Entities.Privilege;
using ShelterApp.Entities.Entities.Privilege.dtos;
using ShelterApp.Entities.Entities.Product;
using ShelterApp.Entities.Entities.Product.dtos;
using ShelterApp.Entities.Entities.Sector;
using ShelterApp.Entities.Entities.Sector.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Business
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<TBL_Blog, SelectBlogDto>();
            CreateMap<TBL_Blog, ListBlogDto>();
            CreateMap<CreateBlogDto, TBL_Blog>();
            CreateMap<SelectBlogDto, CreateBlogDto>();
            CreateMap<UpdateBlogDto, TBL_Blog>();
            CreateMap<SelectBlogDto, UpdateBlogDto>();  



            CreateMap<TBL_Product, SelectProductDto>();
            CreateMap<TBL_Product, ListProductDto>();
            CreateMap<CreateProductDto, TBL_Product>();
            CreateMap<SelectProductDto, CreateProductDto>();
            CreateMap<UpdateProductDto, TBL_Product>();
            CreateMap<SelectProductDto, UpdateProductDto>();



            CreateMap<TBL_Privilege, SelectPrivilegeDto>();
            CreateMap<TBL_Privilege, ListPrivilegeDto>();
            CreateMap<CreatePrivilegeDto, TBL_Privilege>();
            CreateMap<SelectPrivilegeDto, CreatePrivilegeDto>();
            CreateMap<UpdatePrivilegeDto, TBL_Privilege>();
            CreateMap<SelectPrivilegeDto, UpdatePrivilegeDto>();


            CreateMap<TBL_Sector, SelectSectorDto>();
            CreateMap<TBL_Sector, ListSectorDto>();
            CreateMap<CreateSectorDto, TBL_Sector>();
            CreateMap<SelectSectorDto, CreateSectorDto>();
            CreateMap<UpdateSectorDto, TBL_Sector>();
            CreateMap<SelectSectorDto, UpdateSectorDto>();
        }
    }
}
