﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.Core.Utilities.MapperUtilities.Extensions
{
    public static class ObjectMapper
    {
        public static IMapper Mapper { get; set; }

        public static TDestination Map<TSource, TDestination>(this TSource input)
        {
            return Mapper.Map<TSource, TDestination>(input);
        }
    }
}
