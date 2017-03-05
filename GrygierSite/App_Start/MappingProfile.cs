using AutoMapper;
using GrygierSite.Core.Dtos;
using GrygierSite.Core.Models;
using GrygierSite.Core.ViewModels;

namespace GrygierSite
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ViewModel to Model
            Mapper.CreateMap<ProductFormViewModel, Product>();

            // Model to ViewModel
            Mapper.CreateMap<Product, ProductFormViewModel>();

            // Dto to Model
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<CategoryDto, Category>();

            // Model to Dto
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<Category, CategoryDto>();

        }
    }
}