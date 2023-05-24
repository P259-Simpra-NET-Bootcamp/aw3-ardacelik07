using AutoMapper;
using DataLayer.Models;
using SimodevApi.Dtos;
using System.Security.Principal;

namespace SimodevApi
{
    public class MapperProfile :Profile
    {

        public MapperProfile()
        {
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<CategoryRequestDto, Category>();

            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductResponseDto, Product>();

        }
    }
}
