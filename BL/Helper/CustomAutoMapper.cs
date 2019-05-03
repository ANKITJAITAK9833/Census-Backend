using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SHARED.DTOS;
using DAL.ENTITY;
namespace BL.Helper
{    
    /// <summary>
///     Helper Class Contains Mappers Which Convert All Dto's To Entities
/// </summary>
    public class CustomAutoMapper
    {
        public IMapper Mapper;
        public CustomAutoMapper()
        { 
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<HouseListing, HouseListingDto>().ReverseMap();
                cfg.CreateMap<PopulationRegistration, PopulationRegistrationDto>().ReverseMap();
                cfg.CreateMap<UserRequestStatus, UserRequestStatusDto>().ReverseMap();
            });
            Mapper = config.CreateMapper();
        }
    }
}
