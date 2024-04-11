using AutoMapper;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Blog.dtos;
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
        }
    }
}
