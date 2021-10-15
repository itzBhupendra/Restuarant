using AutoMapper;
using Restuarant.Services.ProductAPI.Models;
using Restuarant.Services.ProductAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restuarant.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        { 
           var mappingConfig= new MapperConfiguration(config=> {
               config.CreateMap<ProductDto, Product>();
               config.CreateMap<Product, ProductDto>();

           });

            return mappingConfig;
        }
    }
}
