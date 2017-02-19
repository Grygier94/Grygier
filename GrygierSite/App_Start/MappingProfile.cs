using AutoMapper;
using GrygierSite.Core.Dtos;
using GrygierSite.Core.Models;

namespace GrygierSite
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Dto to Model
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<CategoryDto, Category>();

            // Model to Dto
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<Category, CategoryDto>();

        }
    }
}