using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.CategpryDtos;
using AutoMapper;

namespace ActiviGoApi.Services.Mapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
             CreateMap<Category, CategoryReadDto>();

             CreateMap<CategoryCreateDto, Category>();

            CreateMap<CategoryUpdateDto, Category>()
               .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
