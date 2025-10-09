using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs;
using ActiviGoApi.Services.DTOs.LocationDTOs;
using AutoMapper;

namespace ActiviGoApi.Services.Mapping
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, LocationRequestDTO>();
            CreateMap<Location, UpdateLocationDTO>();
            CreateMap<Location, CreateLocationDTO>();

        }
    }
}
