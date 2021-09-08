using AutoMapper;
using Inventory_System.Models;
using Inventory_System.Dtos;

namespace Inventory_System.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductCreateDto,Product>();
            CreateMap<ProductUpdateDto,Product>();
            CreateMap<UserLoginDto,User>();
        }
    }
}