using AutoMapper;
using Usage.Application.ApiContracts.Queries;
using Usage.Application.Dtos;
using Usage.Application.Features.Categories.Commands.SaveCategory;
using Usage.Application.Features.Categories.Commands.UpdateCategory;
using Usage.Application.Features.CategoryAttributes.Commands.SaveCategoryAttribute;
using Usage.Application.Features.CategoryAttributes.Commands.UpdateCategoryAttribute;
using Usage.Domain.CategoryAggregate;
using Usage.Domain.UserAggregate;

namespace Usage.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Features
            CreateMap<CategoryDto, SaveCategoryCommand>().ReverseMap();
            CreateMap<CategoryDto, UpdateCategoryCommand>().ReverseMap();
            CreateMap<CategoryAttributeDto, SaveCategoryAttributeCommand>().ReverseMap();
            CreateMap<CategoryAttributeDto, UpdateCategoryAttributeCommand>().ReverseMap();
            #endregion

            #region ApiContracts
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, CategoryTreeResponse>().MaxDepth(5).ReverseMap();
            #endregion

            #region Entity<>Dto
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryAttribute, CategoryAttributeDto>().ReverseMap();
            CreateMap<UserDomain, UserModel>().ReverseMap();
            #endregion
        }
    }
}
