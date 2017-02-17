using AutoMapper;
using GrygierSite.Dtos;
using GrygierSite.Models;
using GrygierSite.ViewModels;

namespace GrygierSite
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ViewModel to Model
            Mapper.CreateMap<ProductFormViewModel, Product>();

            // Model to ViewModel
            Mapper.CreateMap<Product, DetailsViewModel>();

            // Dto to Model
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<CategoryDto, Category>();

            // Model to Dto
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<Category, CategoryDto>();

        }
    }
}