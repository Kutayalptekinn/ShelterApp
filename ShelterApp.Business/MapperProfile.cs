using AutoMapper;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Blog.dtos;
using ShelterApp.Entities.Entities.Product;
using ShelterApp.Entities.Entities.Product.dtos;
using ShelterApp.Entities.Entities.Sector;
using ShelterApp.Entities.Entities.Service.dtos;
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



            CreateMap<TBL_Service, SelectServiceDto>();
            CreateMap<TBL_Service, ListServiceDto>();
            CreateMap<CreateServiceDto, TBL_Service>();
            CreateMap<SelectServiceDto, CreateServiceDto>();
            CreateMap<UpdateServiceDto, TBL_Service>();
            CreateMap<SelectServiceDto, UpdateServiceDto>();
        }
    }
}
